using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWaterCollision : MonoBehaviour
{
    //public get serialized and assigning bool won't work
    public bool waterPicked;
    public bool waterOut;
    //public bool bothCondition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Righthand"))
        {
            waterPicked = true;
            //Debug.Log(waterPicked);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Waterbottle"))
        {
            waterOut = true;
            //Debug.Log(waterOut);
        }
    }

    //private void Update()
    //{
    //    if (waterPicked == true && waterOut == true)
    //    {
    //        bothCondition = true;
    //        Debug.Log(bothCondition);
    //    }
    //}
}
