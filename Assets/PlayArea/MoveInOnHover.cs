using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInOnHover : MonoBehaviour
{
    public float dist = 4f;
    public Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
    }
    private void OnEnable()
    {
        transform.position = originalPos;
    }
    private void OnMouseEnter()
    {
        transform.position -= new Vector3(0, 0, dist);
    }

    private void OnMouseExit()
    {
        transform.position = originalPos;
    }
}
