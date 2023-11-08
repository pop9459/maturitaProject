using UnityEngine;

public class Controller : MonoBehaviour {
    public static AudioSource[] audioSources;
         
    public static HPBarController HPcontroller;
    public static Spawner spawner;
    public static DigitDisplayController moneyDisplayController;
    public static DigitDisplayController waveCounter;
    public static TimeButtonController timeButtonController;
    public static AutoPlayButton autoPlayButton;
    public static GameObject restartButton;
    public static bool gameActive = false;
    public static bool autoplay = false;
    public static bool editMode = false;
    public static bool paused = true;
    public static int timeSpeedState = 0;
    public static float playerHealth  = 100f;
    public static float maxHP { get; private set; } = 100f;
    public static float startingMoney = 650;
    public static float money { get; private set; }

    public static Quaternion camPlayspaceRotation = new Quaternion(60, 0, 0, 0);
    private void Awake()
    {
        Time.timeScale = 0; //start paused
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        timeButtonController = GameObject.FindGameObjectWithTag("TimeButtonController").GetComponent<TimeButtonController>();
        HPcontroller = GameObject.FindGameObjectWithTag("HPBar").GetComponent<HPBarController>();
        moneyDisplayController = GameObject.FindGameObjectWithTag("MoneyDisplay").GetComponent<DigitDisplayController>();
        waveCounter = GameObject.FindGameObjectWithTag("WaveCounter").GetComponent<DigitDisplayController>();
        autoPlayButton = GameObject.FindGameObjectWithTag("AutoPlayButton").GetComponent<AutoPlayButton>();
        restartButton = GameObject.FindGameObjectWithTag("RestartButton");
        audioSources = GetComponents<AudioSource>();
    }
    void Start()
    {
        waveCounter.setValue(00);
        addMoney(startingMoney);
        playMusic("menu");

        restartButton.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && editMode == false)
        {
            pause();
            pointCameraToMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!paused) pause();
            else unPause();
        }
    }
    public static void pause()
    {
        playMusic("menu");
        paused = true;
        timeButtonController.setSymbol(0);
        Time.timeScale = 0;
    }
    public static void unPause()
    {
        playMusic("main");
        spawner.nextWave();
        paused = false;
        if(timeSpeedState == 0) nextTimeSpeedState();
        setTimeSpeedAndButtonSymbol();

        restartButton.SetActive(gameActive);
    }
    public static void nextTimeSpeedState()
    {
        if (paused)
        {
            unPause();
            if (timeSpeedState == 0) nextTimeSpeedState();
        }
        else
        {
            timeSpeedState = (timeSpeedState + 1) % 4;
            setTimeSpeedAndButtonSymbol();
        }
    }
    static void setTimeSpeedAndButtonSymbol()
    {
        if (timeSpeedState == 0) playMusic("menu"); 
        else playMusic("main");
        
        if (timeSpeedState == 3)
        {
            timeButtonController.setSymbol(4);
            Time.timeScale = 4;
        }
        else
        {
            timeButtonController.setSymbol(timeSpeedState);
            Time.timeScale = timeSpeedState;
        }
    }
    public static void dealDeamge(float deamge)
    {
        playerHealth -= deamge;
        float hpPercent = Mathf.Clamp((maxHP / playerHealth) * 100, 0, 100);
        HPcontroller.setHpBar(playerHealth);
        if (hpPercent <= 0)
        {
            gameOver();
        }
    }
    public static void addMoney(float val)
    {
        money += val;
        moneyDisplayController.setValue((int)money);
    }
    public static void playMusic(string musicID)
    {
        switch (musicID)
        {
            case "menu":
                foreach (AudioSource source in audioSources) source.Pause();
                audioSources[0].Play();
                break;
            case "main":
                foreach (AudioSource source in audioSources) source.Pause();
                audioSources[1].Play();
                break;
            default:
                foreach (AudioSource source in audioSources) source.Pause();
                break;
        }
    }
    public static void restartGame()
    {
        pause();
        timeSpeedState = 0;
        addMoney(-money);
        addMoney(startingMoney);
        gameActive = false;
        autoPlayButton.disable();
        autoplay = false;
        waveCounter.setValue(0);
        Spawner.waveActive = false;
        Spawner.waveIndex = 0;
        HPcontroller.setHpBar(100);
        playerHealth = maxHP;
        foreach(AudioSource audioSource in audioSources) audioSource.Stop();
        playMusic("menu");
        foreach(GameObject activeEnemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            activeEnemy.GetComponent<EnemyMove>().disable();
        }
        foreach (GameObject activeTurret in GameObject.FindGameObjectsWithTag("Turret"))
        {
            Destroy(activeTurret);
        }
        foreach (GameObject deathParticle in GameObject.FindGameObjectsWithTag("DeathParticle"))
        {
            Destroy(deathParticle);
        }
        spawner.stopWave();
        editMode = false;
    }
    public static void gameOver()
    {
        Debug.Log("game over");
        pointCameraToMenu();
        restartGame();
        restartButton.SetActive(false);
    }
    public static void gameWon()
    {
        Debug.Log("Game won!");
        pointCameraToMenu();
        restartGame();
        restartButton.SetActive(false);
    }
    public static void pointCameraToPlayspace()
    {
        Camera.main.GetComponent<Animator>().SetBool("camLookAtPlayspace", true);
    }
    public static void pointCameraToMenu()
    {
        Camera.main.GetComponent<Animator>().SetBool("camLookAtPlayspace", false);
    }
}