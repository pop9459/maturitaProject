using UnityEngine;

public class BulletController : Projectile
{
    private int hitEnemies;
    public BulletController()
    {
        velocity = 250;
    }
    void Start()
    {
        rb.velocity = transform.forward * velocity;
    }
    protected void FixedUpdate()
    {
        if (Vector3.Distance(startPos, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (hitEnemies < 1 && other.transform.tag == "Enemy")
        {
            hitEnemies++;
            EnemyMove enemyController = other.gameObject.GetComponent<EnemyMove>();
            enemyController.takeDeamge(magnitude);
            Destroy(gameObject);
        }
    }
}
