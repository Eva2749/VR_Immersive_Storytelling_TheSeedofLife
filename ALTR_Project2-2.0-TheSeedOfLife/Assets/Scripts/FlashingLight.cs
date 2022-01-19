using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public float minIntensity;
    public float maxIntensity;
    public float flashSpeed = 0.5f;
    public Light myLight;

    public bool isFlashing = true;
    public float flashTime;


    private void Awake()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Debug.Log(isFlashing);

    //    if(isFlashing)
    //    {
    //        StartFlashing();
    //        StartCoroutine(CheckForFlash());
    //    }
    //    else if(isFlashing == false)
    //    {
    //        myLight.intensity = 3;
    //    }

    //}

   
    public void StartFlashing()
    {
        StartCoroutine(Flash());
    }

    //let it run every frame
    IEnumerator Flash()
    {
        //let it run infinitely
        while (true)
        {
            //https://docs.unity3d.com/ScriptReference/Mathf.Lerp.html Mathf.Lerp
            //https://docs.unity3d.com/ScriptReference/Mathf.PingPong.html Mathf.Pingpong
            myLight.intensity = Mathf.PingPong(Time.time, flashSpeed);
            yield return null;  //the above expression called every frame (similar to creating a background void Update()
        }
    }

    public void StopFlashing()
    {
        StopAllCoroutines();
        myLight.intensity = 0;
    }
    
}
