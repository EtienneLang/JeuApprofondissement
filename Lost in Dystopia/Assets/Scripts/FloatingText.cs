using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool active;
    public bool isStill;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show() 
    {
        active = true;
        go.SetActive(true);
        lastShown = Time.time;
    }

    public void Hide() 
    {
        active = false;
        go.SetActive(false);
    }


    public void UpdateText() 
    {
        if (!active)
            return;
        if (Time.time - lastShown > duration)
            Hide();
        go.transform.position += motion * Time.deltaTime;

    }

}
