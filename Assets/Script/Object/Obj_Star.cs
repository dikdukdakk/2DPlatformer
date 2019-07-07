using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Star : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Player")
            return;

        Destroy(gameObject);
        GameManager.PlayerGrabStar(this);
    }
}
