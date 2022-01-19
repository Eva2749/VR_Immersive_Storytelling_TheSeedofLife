using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorController : MonoBehaviour
{
    //[SerializeField]

    public Material material;
    //MeshRenderer meshRenderer;
    private Color emissionColor;
    public float intensity;

    //get required components
    private void Awake()
    {
        //get the mesh renderer
        //meshRenderer = GetComponent<MeshRenderer>();
        //get the emission color
        emissionColor = material.GetColor("_EmissionColor");        
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
            material.EnableKeyword("_EMISSION");
            //meshRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
            material.SetColor("_EmissionColor", emissionColor*Mathf.PingPong(Time.time, intensity));
            Debug.Log(emissionColor);
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }


    public void StopFlashing()
    {
        StopAllCoroutines();
        //disable emission color
        material.DisableKeyword("_EMISSION");
    }


    //when all puzzles are collected, make all puzzles emiting color

}
