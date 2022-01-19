using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceOnceAudio : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    public AudioSource audio;
    public bool alreadyPlayed = false;
    public bool startRed;

    private bool redLight = false;

    //private void Start()
    //{
    //    audio = GetComponent<AudioSource>();
    //}

    //private void OnTriggerEnter()
    //{
    //    //if (gameObject.CompareTag("Righthand"))
    //    //{

    //    //    audio.Play();
    //    //}

    //    if (!alreadyPlayed)
    //    {
    //        audio.PlayOneShot(SoundToPlay, Volume);
    //        alreadyPlayed = true;
    //    }
    //}
    private void Awake()
    {
        startRed = false;
    }


    public void StartPlaying()
    {
        audio.PlayOneShot(SoundToPlay, Volume);
        if (!redLight)
        {
            StartCoroutine(redLightStart());
            redLight = true;
        }


    }

  

    public void StopPlaying()
    {
        audio.Stop();
    }


    IEnumerator redLightStart()
    {
        yield return new WaitForSeconds(20);
        startRed = true;
    }

}
