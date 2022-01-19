using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllerGreen : MonoBehaviour
{
    // Start is called before the first frame update
    //MeshRenderer meshRenderer;
    private Color tangramEmissionColor;
    private Color doorEmissionColor;

    public float intensity;

    //define the material for tangram and door
    public Material greenTangramMaterial;
    public Material greenDoorMaterial;


    //get required components
    private void Awake()
    {
        //get the emission color
        tangramEmissionColor = greenTangramMaterial.GetColor("_EmissionColor");
        doorEmissionColor = greenDoorMaterial.GetColor("_EmissionColor");
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
            greenTangramMaterial.EnableKeyword("_EMISSION");
            greenDoorMaterial.EnableKeyword("_EMISSION");
            greenTangramMaterial.SetColor("_EmissionColor", Color.green * Mathf.PingPong(Time.time, intensity));
            greenDoorMaterial.SetColor("_EmissionColor", Color.green * Mathf.PingPong(Time.time, intensity));
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        //disable emission color
        greenTangramMaterial.DisableKeyword("_EMISSION");
        greenDoorMaterial.DisableKeyword("_EMISSION");
    }

    public void KeepEmitting()
    {
        //make the tangram keep emitting color
        greenTangramMaterial.EnableKeyword("_EMISSION");
        greenTangramMaterial.SetColor("_EmissionColor", Color.green * intensity);
    }

}
