using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour
{
    public bool lightOn;
    private Light[] directionalLight;
    private Quaternion sunLightRotation;
    private Quaternion moonLightRotation;
    private float lightPitch;

    void Start()
    {
        directionalLight = GetComponentsInChildren<Light>();

        if (lightOn)
        {
            lightPitch = 1;
            sunLightRotation = Quaternion.Euler(lightPitch, 30f, 0f);
            directionalLight[0].transform.rotation = sunLightRotation;
        }
    }

    void Update()
    {
        if (lightOn)
        {
            lightPitch += 0.05f;
            sunLightRotation = Quaternion.Euler(lightPitch, 30f, 0f);
            directionalLight[0].transform.rotation = sunLightRotation;
        }
    }
}
