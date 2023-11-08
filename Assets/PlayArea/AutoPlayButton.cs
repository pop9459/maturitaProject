using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class AutoPlayButton : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] Renderer rend;
    bool state = false;
    Vector3 startPos;
    private void Start()
    {
        startPos = button.transform.localPosition;
    }
    private void OnMouseDown()
    {
        //update on mouse click
        state = !state;
        if(state)
        {
            enable();
        }
        else
        {
            disable();
        }
    }

    public void enable()
    {
        rend.material.SetColor("_Color", Color.HSVToRGB(0.3f, 1, 0.84f));
        button.transform.localPosition = startPos + new Vector3(0, 0, 0.9f);
        Controller.autoplay = state;
    }

    public void disable()
    {
        rend.material.SetColor("_Color", Color.red);
        button.transform.localPosition = startPos;
        Controller.autoplay = state;
    }
}
