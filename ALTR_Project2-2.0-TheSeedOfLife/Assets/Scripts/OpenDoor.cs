using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor: MonoBehaviour
{
    public Transform start;
    public Transform end;
    private float openDegree = 0.0f;
    public float openSpeed;

    public bool isOpen = false;

    public void OpenTheDoor(float t)
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

    public void StartDoorOpen()
    {
        StartCoroutine(IncrementDoor());
    }

    IEnumerator IncrementDoor()
    {
        while (openDegree < 1.0f)
        {
            //if assign Math.MoveTowards, it will reset the function every time the frame runs
            openDegree += openSpeed * Time.deltaTime;
            OpenTheDoor(openDegree);
            //Debug.Log(openDegree);
            yield return null;
        }    
    }

    private void StopDoorOpen()
    {
        StopAllCoroutines();
    }
}


