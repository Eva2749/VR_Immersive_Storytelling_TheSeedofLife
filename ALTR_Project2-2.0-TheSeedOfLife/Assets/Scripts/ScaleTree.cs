using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTree : MonoBehaviour
{
    public GameObject scaleTree;
    public GameObject letter2;
    public float scaleSpeed;
    public bool canScale = false;

    private float scaleChange;
    public float Volume;
    public AudioClip treeGrowingClip;
    public AudioSource treeGrowingAudio;

    public AudioClip endBgmClip;
    public AudioSource endBgmSource;

    public AudioSource startBgmSource;

    private bool playEndBgm;
    


    public void StartScaling()
    {
        //scaleTree.transform.position = new Vector3(0, 0, 0);
        scaleChange = 0;
        canScale = true;
        scaleSpeed = 0.3f;
        //start playing audio
        treeGrowingAudio.PlayOneShot(treeGrowingClip, Volume);
    }

    // Update is called once per frame
    void Update()
    {
        //when StartScaling() is called, start growing trees
        if (scaleChange < 1 && canScale)
        {
            scaleChange = Mathf.MoveTowards(scaleChange, 1.0f, scaleSpeed * Time.deltaTime);
            scaleTree.transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange);
            letter2.SetActive(false);
        }
        else if (scaleChange == 1)
        {
            letter2.SetActive(true);

            if (!playEndBgm)
            {
                endBgmSource.PlayOneShot(endBgmClip, Volume);
                startBgmSource.Stop();
                playEndBgm = true;
            }
        }

    }
}
