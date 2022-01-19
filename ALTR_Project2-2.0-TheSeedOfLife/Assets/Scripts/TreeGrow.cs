using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{
    //declare boolean values for check
    public bool potPlanting;
    public bool isWatering;
    private bool scaleStart = true;

    //get boolean from other scripts
    public ParticleTrigger waterPlanting;
    public ScaleTree treeGrowing;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plantbox"))
        {
            Debug.Log("potPlanting is true");
            potPlanting = true;
        }
    }

    private void Update()
    {
        isWatering = waterPlanting.isDropping;
       
        if (potPlanting == true && isWatering == true && scaleStart == true)
        {
            treeGrowing.StartScaling();
            //make sure it only grow once
            scaleStart = false;

        }
    }


}
