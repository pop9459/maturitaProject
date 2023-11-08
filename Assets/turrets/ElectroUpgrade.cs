using UnityEngine;

public class ElectroUpgrade : TurretUpgrade
{
    public ElectroUpgrade()
    {
        baseValue = 350;
        pathOne = new UpgradePath("max targets", new float[] { 250, 350f, 600f }, new float[] { 10f, 12f, 24f }); //reloadTime
        pathTwo = new UpgradePath("damage", new float[] { 250f, 450f, 600f }, new float[] { 2f, 3f, 5f }); //range
    }
    protected override void UpgradePathOne()
    {
        if (pathOneLevel >= pathOne.costs.Length)
        {
            //max path
        }
        else if (Controller.money >= pathOne.costs[pathOneLevel])
        {
            Controller.addMoney(-pathOne.costs[pathOneLevel]);
            turretController.maxTargets = (int)pathOne.upgradeValues[pathOneLevel];
            base.UpgradePathOne();
        }
    }
    protected override void UpgradePathTwo()
    {
        if (pathTwoLevel >= pathTwo.costs.Length)
        {
            //max path
        }
        else if (Controller.money >= pathTwo.costs[pathTwoLevel])
        {
            Controller.addMoney(-pathTwo.costs[pathTwoLevel]);
            turretController.damage = pathTwo.upgradeValues[pathTwoLevel];
            base.UpgradePathTwo();
        }
    }
}
