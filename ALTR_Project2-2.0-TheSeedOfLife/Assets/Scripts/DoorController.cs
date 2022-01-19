using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //check each action's completion status
    private bool step1Complete = false;
    private bool step2Complete = false;
    private bool step3Complete = false;
    private bool step4Complete = false;

    //get script from the light objects
    //https://www.codegrepper.com/code-examples/csharp/call+script+in+another+script+unity
    //public ColorController light1Script;
    //public ColorController light2Script;
    //public ColorController light3Script;
    //public ColorController light4Script;

    //color scripts for the cabinet doors
    public ColorControllerRed color1Script;
    public ColorControllerYellow color2Script;
    public ColorControllerGreen color3Script;
    public ColorControllerBlue color4Script;

    //reference to the checkCollision script
    public checkPotCollision plantPot;
    public checkAshCollision ashPot;
    public checkSeedCollision seedPot;
    public checkWaterCollision waterPot;

    public OnceOnceAudio letter1Audio;
    public OpenDoor doorTrigger;

    //puzzle complete sound
    public AudioClip puzzleCompleteClip;
    public AudioSource puzzleCompleteSource;
    public float Volume;

    Coroutine timeout;
    private bool doorOpen = false;
    private bool doorSound = false;

    //need to define the bool before assigning value to it
    //pick the pot first
    public bool potPick;
    public bool potExit;

    //ash second
    public bool ashPick;
    public bool ashExit;

    //seed third
    public bool seedPick;
    public bool seedExit;

    //last water bottle
    public bool waterPick;
    public bool waterExit;

    public bool redLightStart;


    private void Start()
    {
        //disable all emission colors at first
        color1Script.StopFlashing();
        color2Script.StopFlashing();
        color3Script.StopFlashing();
        color4Script.StopFlashing();     
    }

    private void Update()
    {
        //get the reference value
        potPick = plantPot.potPicked;
        potExit = plantPot.potOut;

        ashPick = ashPot.ashPicked;
        ashExit = ashPot.ashOut;

        seedPick = seedPot.seedPicked;
        seedExit = seedPot.seedOut;

        waterPick = waterPot.waterPicked;
        waterExit = waterPot.waterOut;

        redLightStart = letter1Audio.startRed;
        //Debug.Log(redLightStart);

        if(redLightStart)
        {
            color1Script.Flash();
            checkAction1();
        }

        if (step1Complete)
        {
            //make light1 constant and make light2 flash
            color1Script.StopFlashing();
            color2Script.Flash();
            //Debug.Log("step1complete!");
            //check action2
            checkAction2();
            //make sure it only run once
            step1Complete = false;
        }

        if (step2Complete)
        {
            //make light2 constant and make light3 flash
            color2Script.StopFlashing();
            color3Script.Flash();
            //Debug.Log("step2complete!");
            //check action3
            checkAction3();
            step2Complete = false;
        }

        if (step3Complete)
        {
            //make light3 constant and make light4 flash
            color3Script.StopFlashing();
            color4Script.Flash();
            //Debug.Log("step3complete!");
            checkAction4();
            step3Complete = false; ;
        }

        if (step4Complete)
        {
            //make light3 constant and make light4 flash
            color4Script.StopFlashing();
     
            //Debug.Log("step4complete! Now go out to grow trees");
            //open the door
            DoorOpen();
            step4Complete = false;
        }


    }


    public void checkAction1()
    {
        if (potPick == true && potExit == true)
        {
            step1Complete = true;
        }
    }


    public void checkAction2()
    {
        if (ashPick == true && ashExit == true)
        {
            step2Complete = true;
        }
    }

    public void checkAction3()
    {
        if (seedPick == true && seedExit == true)
        {
            step3Complete = true;
        }
    }

    public void checkAction4()
    {
        if (waterPick == true && waterExit == true)
        {
            step4Complete = true;
        }
    }


    public void DoorOpen()
    {
        //play the puzzle complete audio to indicate completion and trigger door open sound
        //first, trigger the sound

        //open the door after the puzzle complete indication sound
        //start coroutine
        if(doorOpen == false && doorSound == false)
        {
            puzzleCompleteSource.PlayOneShot(puzzleCompleteClip, Volume);
            doorSound = true;
            timeout = StartCoroutine(TimeOut());
        }

        IEnumerator TimeOut()
        {
            yield return new WaitForSeconds(1);
            doorTrigger.StartDoorOpen();
            doorOpen = true;
        }

        ClearTimeOut();


        //make the tangram emitting color at a certain intensity
        color1Script.KeepEmitting();
        color2Script.KeepEmitting();
        color3Script.KeepEmitting();
        color4Script.KeepEmitting();
    }

    private void ClearTimeOut()
    {
        if (doorOpen == true)
        {
            StopCoroutine(timeout);
        }
    }


}
