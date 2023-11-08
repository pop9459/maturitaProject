using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarController : MonoBehaviour
{
    private Transform tf;
    private void Awake()
    {
        tf = transform;
    }
    public void setHpBar(float hpPercent)
    {
        tf.localPosition = new Vector3(Mathf.Clamp(((hpPercent-100)/20), -5, 0), 0, 0);
        tf.localScale = new Vector3(Mathf.Clamp((hpPercent / 10), 0, 10), 1, 1);
    }
}
