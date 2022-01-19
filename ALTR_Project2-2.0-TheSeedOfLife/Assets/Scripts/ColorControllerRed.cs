using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllerRed : MonoBehaviour
{
    //MeshRenderer meshRenderer;
    private Color tangramEmissionColor;
    private Color doorEmissionColor;

    //define the material for tangram and door
    public Material RedTangramMaterial;
    public Material RedDoorMaterial;

    public float intensity;

    //get required components
    private void Awake()
    {     
        //get the emission color
        tangramEmissionColor = RedTangramMaterial.GetColor("_EmissionColor");
        doorEmissionColor = RedDoorMaterial.GetColor("_EmissionColor");
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
            // Enables tangram and door material
            RedTangramMaterial.EnableKeyword("_EMISSION");
            RedDoorMaterial.EnableKeyword("_EMISSION");
            RedTangramMaterial.SetColor("_EmissionColor", Color.red * Mathf.PingPong(Time.time, intensity));
            RedDoorMaterial.SetColor("_EmissionColor", Color.red*Mathf.PingPong(Time.time, intensity));
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        //set intensity of the emission color to a value
        //intensity = 0;

        //disable emission color
        RedTangramMaterial.DisableKeyword("_EMISSION");
        RedDoorMaterial.DisableKeyword("_EMISSION");
    }

    public void KeepEmitting()
    {
        //make the tangram keep emitting color
        RedTangramMaterial.EnableKeyword("_EMISSION");
        RedTangramMaterial.SetColor("_EmissionColor", Color.red * intensity);
    }

}
