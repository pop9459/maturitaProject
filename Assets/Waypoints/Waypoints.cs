using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Vector3[] waypoints;

    public void Awake()
    {
        waypoints = new Vector3[transform.childCount];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i).position;
        }
    }
}
