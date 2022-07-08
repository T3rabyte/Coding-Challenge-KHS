using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light light;

    private void Start()
    {
        light.gameObject.SetActive(false);
    }

    public void useObject() 
    {
        if (light.gameObject.activeSelf) 
        {
            light.gameObject.SetActive(false);
        }
        else 
        {
            light.gameObject.SetActive(true);
        }
    }
}
