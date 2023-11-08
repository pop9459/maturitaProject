using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    [SerializeField] protected GameObject TurretHead;
    [SerializeField] protected GameObject TurretBarrel;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform shootingPoint;
    [SerializeField] protected ParticleSystem fireFx;

    [SerializeField] protected TurretUpgrade turretUpgrade;

    public float range;
    public float damage;
    public float reloadTime;
    protected float nextShot = 0;
    public int maxTargets;

    public List<Booster> boosters = new List<Booster> { };
    public float boostedReloadTime;
    public float boostedDamage;

    protected Transform target;
    protected Vector3 targetPos;
    private void Awake()
    {
        boostedReloadTime = reloadTime;
        boostedDamage = damage;
    }
    private void OnEnable()
    {
        //Booster.UpdateBoosterTowers();
    }
    protected virtual void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.1f);
    }
    public virtual void updateTarget()
    {
        EnemyMove[] enemies = Spawner.activeEnemyes.ToArray();
        float closest = Mathf.Infinity;
        EnemyMove closestEnemy = null;
        foreach(EnemyMove enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if(distance < closest && distance < range)
            {
                closest = distance;
                closestEnemy = enemy;
            }
        }
        if(closest < range)
        {
            target = closestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    protected virtual void FixedUpdate()
    {
        if (target != null)
        {
            if (Time.time >= nextShot)
            {
                lookAtTarget();
                nextShot = Time.time + reloadTime;
                fire();
            }
        }
    }
    protected virtual void lookAtTarget()
    {
        targetPos = target.position;// + new Vector3(0, -1.2f, 0); //look at enemy with y offset
        TurretHead.transform.LookAt(targetPos);
        shootingPoint.transform.LookAt(targetPos);
    }
    protected virtual void fire()
    {
        fireFx?.Play(); //fx
        Projectile projectileController = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation).GetComponent<Projectile>();
        projectileController.magnitude = damage;
        projectileController.range = range;
        projectileController.targetPos = target.position;
        projectileController.gameObject.SetActive(true);
    }
    public void updateBoostValues()
    {
        boostedReloadTime = reloadTime;
        boostedDamage = damage;
        foreach (Booster booster in boosters)
        {
            boostedReloadTime *= booster.reloadReductionPower;
            boostedDamage += booster.damageBoostingPower;
        }
    }
    void OnMouseDown()
    {
        if(!Controller.editMode) turretUpgrade.enabled = true;
    }
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawRay(shootingPoint.position, transform.forward * range);
    }
}
