using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject Enemy;
    public static List<EnemyMove> enemyBuffer = new List<EnemyMove> { };
    public static List<EnemyMove> activeEnemyes = new List<EnemyMove> { };
    public int maxActiveEnemyes { get; private set; } = 1000;
    public static int waveIndex = 0;
    public static bool waveActive = false;
    public static bool waveFinished = false;
    Vector3 startPos;
    Coroutine activeWave;
    void Awake()
    { 
        startPos = transform.position + new Vector3(0, 0.5f, 0);
    }
    private void Start()
    {
        //prebuffer blank inactive enemyes
        for (int i = 0; i < maxActiveEnemyes; i++)
        {
            GameObject newEnemy = Instantiate(Enemy, startPos, new Quaternion());
            newEnemy.SetActive(false);
            enemyBuffer.Add(newEnemy.GetComponent<EnemyMove>());
        }
    }
    private void Update()
    {
        if(activeEnemyes.Count <= 0 && waveFinished && waveActive)
        {
            if (waveIndex + 1 >= Waves.waves.Count)
            {
                Controller.gameWon();
            }
            else
            {
                //wave finished sucessfully
                Controller.addMoney(100 + waveIndex);
                waveIndex++;
                waveActive = false;
                if(Controller.autoplay == true)
                {
                    nextWave();
                }
                else
                {
                    Controller.pause();
                }
            }
        }
    }
    public void nextWave()
    {
        if (waveActive)
        {
            Debug.Log("wave already active!");
        }
        else
        {
            waveFinished = false;
            Controller.gameActive = true;
            activeWave = StartCoroutine(startWave(Waves.waves[waveIndex]));
        }
    }
    public void stopWave()
    {
        if(activeWave != null) StopCoroutine(activeWave);
    }
    IEnumerator startWave(Wave wave)
    {
        Controller.waveCounter.setValue(waveIndex+1);
        waveActive = true;
        for (int i = 0; i < wave.magnitudes.GetLength(0); i++)
        {
            for (int j = 0; j < wave.magnitudes[i,0]; j++)
            {
                EnemyMove enemyToSpawn = enemyBuffer[0];
                enemyBuffer.Remove(enemyToSpawn);
                activeEnemyes.Add(enemyToSpawn);
                enemyToSpawn.transform.position = startPos;
                enemyToSpawn.magnitude = wave.magnitudes[i, 1];
                enemyToSpawn.gameObject.SetActive(true);
                
                yield return new WaitForSeconds(wave.spawnDelay);
            }
        }
        waveFinished = true;
    }
}
class Wave {
    public float spawnDelay;
    public float[,] magnitudes;
    public Wave(float spawnDelay, float[,] magnitudes)
    {
        this.spawnDelay = spawnDelay;
        this.magnitudes = magnitudes;
    }
}
