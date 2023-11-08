using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterUpgrade : TurretUpgrade
{
    public BoosterUpgrade()
    {
        baseValue = 1200;
        pathOne = new UpgradePath("bomb size", new float[] { 250f, 500f, 750f }, new float[] { 2f, 3f, 4f }); //reloadTime
        pathTwo = new UpgradePath("range", new float[] { 150f, 300f, 600f }, new float[] { 14f, 18f, 22f }); //range
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
            turretController.damage = pathOne.upgradeValues[pathOneLevel];
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
            turretController.range = pathTwo.upgradeValues[pathTwoLevel];
            base.UpgradePathTwo();
        }
    }
}
