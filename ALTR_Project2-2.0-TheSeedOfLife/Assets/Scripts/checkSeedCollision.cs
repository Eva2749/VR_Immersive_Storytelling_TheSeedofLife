using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSeedCollision : MonoBehaviour
{
    //public get serialized and assigning bool won't work
    public bool seedPicked;
    public bool seedOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Righthand"))
        {
            seedPicked = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Seed"))
        {
            seedOut = true;
        }
    }
}
