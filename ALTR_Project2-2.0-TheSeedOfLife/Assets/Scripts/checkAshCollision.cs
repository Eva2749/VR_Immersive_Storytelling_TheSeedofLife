using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAshCollision : MonoBehaviour
{
    //public get serialized and assigning bool won't work
    public bool ashPicked;
    public bool ashOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Righthand"))
        {
            ashPicked = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ash"))
        {
            ashOut = true;
        }
    }
}
