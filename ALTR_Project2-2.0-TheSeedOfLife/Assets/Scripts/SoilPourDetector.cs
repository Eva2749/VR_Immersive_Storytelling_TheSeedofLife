using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SoilPourDetector : MonoBehaviour
{
    //variables for soil pouring interaction
    ParticleSystem soilDropSystem;
    public int pourThreshold = 60;   
    public bool isPouring = false;

    public bool soilReady;

    //variables for soil pouring sound
    public AudioSource soilPouringSource;
    public AudioClip soilPouringClip;
    public float volume;

    private void Awake()
    {
        soilDropSystem = GetComponentInChildren<ParticleSystem>();
        soilReady = false;
    }


    private void Update()
    {
        //bool pourCheck = CalculatePourAngle() < pourThreshold;
        bool pourCheck = CheckForAngle();

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;
            if(isPouring)
            {
                StartPour();
                soilReady = true;
            }
            else
            {
                EndPour();
            }
        }

    }

    private void StartPour()
    {
        soilDropSystem.Play();
        soilPouringSource.PlayOneShot(soilPouringClip, volume);
    }

    private void EndPour()
    {      
        soilDropSystem.Stop();
        soilPouringSource.Stop();
    }


    //private float CalculatePourAngle()
    //{
    //    //Convert radins to degrees
    //    //https://docs.unity3d.com/ScriptReference/Mathf.Rad2Deg.html
    //    return transform.forward.y * Mathf.Rad2Deg;
    //}


    private bool CheckForAngle()
    {
        //the dot function sets a vector that compares with the project's vector
        return Vector3.Dot(Vector3.down, transform.up) > 0;

    }

}
