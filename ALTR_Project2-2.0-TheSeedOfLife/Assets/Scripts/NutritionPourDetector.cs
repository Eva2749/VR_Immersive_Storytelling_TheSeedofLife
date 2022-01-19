using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NutritionPourDetector : MonoBehaviour
{
    //variables for nutrition pouring interaction
    ParticleSystem nutritionDropSystem;
    public int pourThreshold = 60;   
    public bool isPouring = false;

    public bool nutritionReady;


    //variables for nutrition pouring sound
    public AudioSource nutritionPouringSource;
    public AudioClip nutritionPouringClip;
    public float volume;

    private void Awake()
    {
        nutritionDropSystem = GetComponentInChildren<ParticleSystem>();
        nutritionReady = false;
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
                nutritionReady = true;
            }
            else
            {
                EndPour();
            }
        }

    }

    private void StartPour()
    {
        nutritionDropSystem.Play();
        nutritionPouringSource.PlayOneShot(nutritionPouringClip, volume);
    }

    private void EndPour()
    {      
        nutritionDropSystem.Stop();
        nutritionPouringSource.Stop();
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
    //    GameObject streamObject = Instantiate(nutritionStream, origin.position, transform)
    //    return streamObject.GetComponent<Stream>();
    //}

}
