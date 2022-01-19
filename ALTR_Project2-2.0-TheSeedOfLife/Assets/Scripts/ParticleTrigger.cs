using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    //used to control the trigger event only once
    bool hasNotTriggered;
    public bool isDropping;
    int particleCount = 0;

    //reference to the scaleTree script
    //public ScaleTree treeGrow;

    //https://docs.unity3d.com/Manual/PartSysTriggersModule.html
   
    private void Start()
    {
        OnParticleTrigger();
        hasNotTriggered = true;
        isDropping = false;
    }

    void OnParticleTrigger()
    {
        
        //get particle system
        ParticleSystem ps = GetComponent<ParticleSystem>();
        //access particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        // get the entered particles
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);

        //count the number of particles entered
        particleCount += numEnter;

        //if particles entered reach number 10
        if (particleCount > 10 && hasNotTriggered) 
        {
            //planting condition meet
            isDropping = true;
            //only for once
            hasNotTriggered = false;
        }
        
        //Debug.Log("Particle triggers");
        //// re-assign the modified particles back into the particle system
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
    }
}
