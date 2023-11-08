public class CanonUpgrade : TurretUpgrade
{
    public CanonUpgrade()
    {
        baseValue = 300;
        pathOne = new UpgradePath("reload time", new float[] {210f, 250f, 400f}, new float[] {0.75f, 0.5f, 0.25f}); //reloadTime
        pathTwo = new UpgradePath("range", new float[] {50f, 100f, 150f }, new float[] { 12f, 16f, 20f}); //range
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
            turretController.reloadTime = pathOne.upgradeValues[pathOneLevel];
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
