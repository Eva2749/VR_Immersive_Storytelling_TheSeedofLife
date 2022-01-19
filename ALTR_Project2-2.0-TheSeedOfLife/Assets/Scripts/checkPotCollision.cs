using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPotCollision : MonoBehaviour
{
    //public get serialized and assigning bool won't work
    public bool potPicked;
    public bool potOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Righthand"))
        {
            potPicked = true;
            Debug.Log("potPicked");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Plantbox"))
        {
            potOut = true;
            Debug.Log("potOut");
        }
    }
}
