using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_KeySliver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.current.isGetKey = true;
        }
    }
}
