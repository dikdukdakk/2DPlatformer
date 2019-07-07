using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Heart : MonoBehaviour
{
    private int countHeart;
    public GameObject destroyImapact;

    private void Update()
    {
        countHeart = PlayerHeart.current.heart;
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if (hitinfo.tag == "Player" && countHeart != 3)
        {
            PlayerHeart.current.heart++;
            Destroy(gameObject);
        }
    }
}
