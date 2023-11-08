using UnityEngine;

public class Catapult : TurretController {
    [SerializeField] protected Animator animator;
    public void Awake() {
        damage = 1;
        range = 10;
    }
    protected override void fire()
    {
        animator.SetBool("Fire", false);
        animator.SetBool("Fire", true);
        base.fire();
    }
    protected override void lookAtTarget()
    {
        targetPos = new Vector3(target.position.x, TurretHead.transform.position.y, target.position.z);
        TurretHead.transform.LookAt(targetPos);
    }
}
