using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Letter2True : MonoBehaviour
{
   public bool isWatering;
//    public GameObject letter2;

//    public Renderer rend;
//    public void visibility()
//    {
//        rend = letter2.GetComponent<Renderer>();
//        if (isWatering == true)
//        {
//            rend.enabled = true;
//        }
//        else
//        {
//            rend.enabled = false;

//        }


//    }

    public GameObject letter2;

  


    //private void Start()
    //{
    //    letter2 = GetComponent<GameObject>();
        
    //}

    private void Update()
    {
        if (isWatering == true)
        {
            letter2.SetActive(true);
        }
        else
        {
            letter2.SetActive(false);
        }
    }

}
