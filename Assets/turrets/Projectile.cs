using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float range = 10;
    public float magnitude = 1;
    public Vector3 targetPos;

    protected float velocity = 100;
    protected Rigidbody rb;
    protected Vector3 startPos;

    protected virtual void Awake()
    {
        Physics.autoSyncTransforms = true;
        startPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }
}
