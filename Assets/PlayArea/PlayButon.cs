using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButon : MonoBehaviour
{
    private void OnMouseDown()
    {
        Controller.pointCameraToPlayspace();
    }
}
