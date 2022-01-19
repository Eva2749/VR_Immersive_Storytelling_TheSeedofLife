using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllerYellow : MonoBehaviour
{
    // Start is called before the first frame update
    //MeshRenderer meshRenderer;
    private Color tangramEmissionColor;
    private Color doorEmissionColor;

    public float intensity;

    //define the material for tangram and door
    public Material YellowTangramMaterial;
    public Material YellowDoorMaterial;


    //get required components
    private void Awake()
    {
        //get the mesh renderer
        //meshRenderer = GetComponent<MeshRenderer>();
        //get the emission color
        tangramEmissionColor = YellowTangramMaterial.GetColor("_EmissionColor");
        doorEmissionColor = YellowDoorMaterial.GetColor("_EmissionColor");
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
            YellowTangramMaterial.EnableKeyword("_EMISSION");
            YellowDoorMaterial.EnableKeyword("_EMISSION");
            YellowTangramMaterial.SetColor("_EmissionColor", Color.yellow * Mathf.PingPong(Time.time, intensity));
            YellowDoorMaterial.SetColor("_EmissionColor", Color.yellow * Mathf.PingPong(Time.time, intensity));
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        //disable emission color
        YellowTangramMaterial.DisableKeyword("_EMISSION");
        YellowDoorMaterial.DisableKeyword("_EMISSION");
    }


    public void KeepEmitting()
    {
        //make the tangram keep emitting color
        YellowTangramMaterial.EnableKeyword("_EMISSION");
        YellowTangramMaterial.SetColor("_EmissionColor", Color.yellow * intensity);
    }
}
