using UnityEngine;

public class TurretUpgrade : MonoBehaviour 
{
    protected TurretController turretController;
    
    protected int pathOneLevel = 0;
    protected int pathTwoLevel = 0;

    protected UpgradePath pathOne;
    protected UpgradePath pathTwo;

    public float baseValue;
    public float value;

    protected virtual void Awake()
    {
        value = baseValue;
        turretController = GetComponent<TurretController>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            enabled = false;
        }
    }
    private void OnEnable()
    {
        Controller.editMode = true;
        UpgradeGUI.instance.gameObject.SetActive(true);
        UpgradeGUI.OnUpgradeClick += PathUpgrade;
        UpdateGui();
    }
    private void OnDisable()
    {
        Controller.editMode = false;
        UpgradeGUI.instance.gameObject.SetActive(false);
        UpgradeGUI.OnUpgradeClick -= PathUpgrade;
    }
    protected virtual void PathUpgrade(int path)
    {
        switch(path)
        {
            case -1:
                SellTower();
                break;
            case 0:
                UpgradePathOne();
                break;
            case 1:
                UpgradePathTwo();
                break;
            default:
                Debug.Log("invalid upgrade path");
                break;
        }
        UpdateGui();
    }
    protected virtual void SellTower()
    {
        Controller.addMoney(value * 0.8f);
        Destroy(gameObject);
    }
    protected virtual void UpgradePathOne()
    {
        pathOneLevel++;
        value += pathOne.costs[pathOneLevel];
    }
    protected virtual void UpgradePathTwo()
    {
        value += pathTwo.costs[pathTwoLevel];
        pathTwoLevel++;
    }
    protected virtual void UpdateGui()
    {
        //sell button
        UpgradeGUI.instance.sellButtonText.text = "Sell: " + value * 0.8f;
        //path one
        UpgradeGUI.instance.pathOneTopText.text = pathOne.pathName + " Lvl: " + pathOneLevel;
        if (pathOneLevel < pathOne.costs.Length) UpgradeGUI.instance.pathOneButtonText.text = pathOne.costs[pathOneLevel].ToString() + "$ => " + pathOne.upgradeValues[pathOneLevel].ToString();
        else UpgradeGUI.instance.pathOneButtonText.text = "Max";

        //path two
        UpgradeGUI.instance.pathTwoTopText.text = pathTwo.pathName + " Lvl: " + pathTwoLevel;
        if (pathTwoLevel < pathTwo.costs.Length) UpgradeGUI.instance.pathTwoButtonText.text = pathTwo.costs[pathTwoLevel].ToString() + "$ => " + pathTwo.upgradeValues[pathTwoLevel].ToString();
        else UpgradeGUI.instance.pathTwoButtonText.text = "Max";
    }
}
public class UpgradePath {
    public string pathName;
    public float[] costs;
    public float[] upgradeValues;
    public UpgradePath(string pathName, float[] costs, float[] upgradeValues)
    {
        this.pathName = pathName;
        this.costs = costs;
        this.upgradeValues = upgradeValues;
    }
}