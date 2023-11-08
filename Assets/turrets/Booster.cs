using System;
using System.Collections.Generic;
using UnityEngine;

public class Booster : TurretController {
    public static List<Booster> instances = new List<Booster> { };

    public List<TurretController> affectedTurrets = new List<TurretController> { };
    public int damageBoostingPower = 1;
    public float reloadReductionPower = 1;
    private void Awake()
    {
        instances.Add(this);
        range = 9;
    }
    protected override void Start()
    {
    }
    private void OnDestroy()
    {
        foreach (TurretController turret in affectedTurrets)
        {
            turret.boosters.Remove(this);
            turret.updateBoostValues();
        }
        instances.Remove(this);
    }
    public override void updateTarget()
    {
        foreach (GameObject turret in GameObject.FindGameObjectsWithTag("Turret"))
        {
            if (Vector3.Distance(transform.position, turret.transform.position) <= range)
                affectedTurrets.Add(turret.GetComponent<TurretController>());
        }
    }
    public void updateBoost()
    {
        updateTarget();
        foreach(TurretController turret in affectedTurrets)
        {
            turret.boosters.Add(this);
            turret.updateBoostValues();
        }
    }
    protected override void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    public static void UpdateBoosterTowers()
    {
        foreach(Booster booster in instances) {
            booster.updateTarget();
        }
    }
}
