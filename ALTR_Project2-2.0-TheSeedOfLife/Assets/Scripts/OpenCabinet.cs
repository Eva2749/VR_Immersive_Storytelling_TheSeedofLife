using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinet: MonoBehaviour
{
    public Transform start;
    public Transform end;

    public bool isOpen = false;

    public void OpenDoor(float t)
    {
        transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, t);
        if (t > 0.5f)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }


}


