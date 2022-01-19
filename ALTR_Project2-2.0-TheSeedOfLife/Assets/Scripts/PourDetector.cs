using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PourDetector : MonoBehaviour
{
    //variables for water pouring interaction
    ParticleSystem waterDropSystem;
    public int pourThreshold = 60;   
    public bool isPouring = false;

    //variables for water pouring sound
    public AudioSource waterPouringSource;
    public AudioClip waterPouringClip;
    public float volume;

    private void Awake()
    {
        waterDropSystem = GetComponentInChildren<ParticleSystem>();
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
            }
            else
            {
                EndPour();
            }
        }

    }

    private void StartPour()
    {
        waterDropSystem.Play();
        waterPouringSource.PlayOneShot(waterPouringClip, volume);
    }

    private void EndPour()
    {      
        waterDropSystem.Stop();
        waterPouringSource.Stop();
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

    //private Stream CreateStream()
    //{
    //    GameObject streamObject = Instantiate(waterStream, origin.position, transform)
    //    return streamObject.GetComponent<Stream>();
    //}

}
