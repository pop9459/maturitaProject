using UnityEngine;

public class BombScript : Projectile
{
    public BombScript()
    {
        velocity = 2f;
    }
    float animationProgress;
    Vector3 curveMidpoint;
    float splashRange = 6f;
    float curveHeight = 3f;
    protected override void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPos = transform.position;
        curveMidpoint = startPos + new Vector3(targetPos.x/2, startPos.y + curveHeight, targetPos.z / 2);
    }
    private void FixedUpdate()
    {
        if (animationProgress < 1.0f)
        {
            animationProgress += velocity * Time.deltaTime;

            Vector3 m1 = Vector3.Lerp(startPos, curveMidpoint, animationProgress);
            Vector3 m2 = Vector3.Lerp(curveMidpoint, targetPos, animationProgress);
            gameObject.transform.position = Vector3.Lerp(m1, m2, animationProgress);
        }
        else
        {
            //anim done
            EnemyMove[] activeEnemies = Spawner.activeEnemyes.ToArray();
            foreach(EnemyMove enemy in activeEnemies)
            {
                if(Vector3.Distance(enemy.transform.position, transform.position) <= splashRange) {
                    enemy.takeDeamge(magnitude);
                }
            }
            Destroy(gameObject);
        }

    }
}
