using System.Collections.Generic;
using UnityEngine;

public class Electro : TurretController
{
    List<EnemyMove> targets = new List<EnemyMove> { };
    public List<ParticleSystem> particleEffects;
    public void Awake()
    {
        damage = 1;
        range = 9;
        maxTargets = 8;
        reloadTime = 4;
    }
    protected override void Start()
    {
    }
    protected override void FixedUpdate()
    {
        if (Time.time >= nextShot)
        {
            EffectDisable();
            updateTarget();
            fire();
            nextShot = Time.time + reloadTime;
        }
        else EffectPlay();
    }
    public override void updateTarget()
    {
        EnemyMove[] enemies = Spawner.activeEnemyes.ToArray();
        targets.Clear();
        foreach (EnemyMove enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < range)
            {
                if(targets.Count < maxTargets)
                {
                    targets.Add(enemy);
                }
                else
                {
                    return;
                }
            }
        }
    }
    protected override void fire()
    {
        foreach(EnemyMove enemy in targets)
        {
            enemy.takeDeamge(damage);
        }
    }

    void EffectPlay()
    {
        if (particleEffects.Count > 0)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                // effects[i].Play();
                if (!particleEffects[i].transform.gameObject.activeSelf)
                {
                    particleEffects[i].transform.gameObject.SetActive(true);
                }
            }
        }
    }
    void EffectDisable()
    {
        if (particleEffects.Count > 0)
        {
            for (int i = 0; i < particleEffects.Count; i++)
            {
                if (particleEffects[i].transform.gameObject.activeSelf)
                {
                    particleEffects[i].transform.gameObject.SetActive(false);
                }
            }
        }
    }
    protected override void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
