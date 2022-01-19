using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllerBlue : MonoBehaviour
{
    // Start is called before the first frame update
    //MeshRenderer meshRenderer;
    private Color tangramEmissionColor;
    private Color doorEmissionColor;

    public float intensity;

    //define the material for tangram and door
    public Material blueTangramMaterial;
    public Material blueDoorMaterial;


    //get required components
    private void Awake()
    {
        //get the emission color
        tangramEmissionColor = blueTangramMaterial.GetColor("_EmissionColor");
        doorEmissionColor = blueDoorMaterial.GetColor("_EmissionColor");
    }

    public void Flash()
    {
        StartCoroutine(StartFlashing());
    }

    //let it run every frame
    IEnumerator StartFlashing()
    {
        //let it run infinitely
        while (true)
        {
            // Enables emission for the material, and make the material use
            // realtime emission
            blueTangramMaterial.EnableKeyword("_EMISSION");
            blueDoorMaterial.EnableKeyword("_EMISSION");
            blueTangramMaterial.SetColor("_EmissionColor", Color.blue * Mathf.PingPong(Time.time, intensity));
            blueDoorMaterial.SetColor("_EmissionColor", Color.blue * Mathf.PingPong(Time.time, intensity));
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        //disable emission color
        blueTangramMaterial.DisableKeyword("_EMISSION");
        blueDoorMaterial.DisableKeyword("_EMISSION");
    }


    public void KeepEmitting()
    {
        //make the tangram keep emitting color
        blueTangramMaterial.EnableKeyword("_EMISSION");
        blueTangramMaterial.SetColor("_EmissionColor", Color.blue * intensity);
    }
}
