using UnityEngine;

public class TimeButtonController : MonoBehaviour {
    public GameObject[] buttonSymbols;

    private void Awake()
    {
        setSymbol(Controller.timeSpeedState);
    }

    /// <param name="state">0=Pause, 1=1x, 2=2x, 3=4x</param>
    public void setSymbol(int state)
    {
        switch(state)
        {
            case 0:
                displaySymbol(0); break;
            case 1:
                displaySymbol(1); break;
            case 2:
                displaySymbol(2); break;
            case 4:
                displaySymbol(3); break;
            default:
                Debug.Log("Unknown button state - cannot display");
                break;
        }
    }
    void displaySymbol(int symbol)
    {
        for (int i = 0; i < buttonSymbols.Length; i++)
        {
            if(i == symbol) { buttonSymbols[i].SetActive(true); }
            else { buttonSymbols[i].SetActive(false); }
        }
    }
    void OnMouseDown()
    {
        Controller.nextTimeSpeedState();
    }
}
