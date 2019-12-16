using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour
{
    private Light[] directionalLight;
    private Quaternion sunLightRotation;
    private Quaternion moonLightRotation;
    private float lightPitch;

    void Start()
    {
        directionalLight = GetComponentsInChildren<Light>();

        lightPitch = 1;
        sunLightRotation = Quaternion.Euler(lightPitch, 30f, 0f);
        directionalLight[0].transform.rotation = sunLightRotation;
        moonLightRotation = Quaternion.Euler(lightPitch + 180f, 30f, 0f);
        directionalLight[1].transform.rotation = moonLightRotation;
    }

    void Update()
    {
        lightPitch += 0.05f;
        sunLightRotation = Quaternion.Euler(lightPitch, 30f, 0f);
        directionalLight[0].transform.rotation = sunLightRotation;
        moonLightRotation = Quaternion.Euler(lightPitch + 180f, 30f, 0f);
        directionalLight[1].transform.rotation = moonLightRotation;
    }
}
