using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator openDoor;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player" && GameManager.current.isGetKey == true)
        {
            UIManager.current.BTOpenDoor.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Player")
        {
            UIManager.current.BTOpenDoor.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        openDoor.enabled = true;
    }
}
