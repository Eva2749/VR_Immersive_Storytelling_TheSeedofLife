using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverLetter : MonoBehaviour
{
   
    public GameObject letterCover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            letterCover.SetActive(false);
        }
    }
}