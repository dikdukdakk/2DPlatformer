using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : MonoBehaviour
{
    [Header("Sword Properties")]
    public int damage = 1;
    public BoxCollider2D boxcol;

    void Update()
    {
        if (Input.GetButtonDown("Z"))
        {
            boxcol.enabled = true;
            Invoke("w8boxenabled", 0.25f);
        }
    }

    void w8boxenabled()
    {
        boxcol.enabled = false;
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Object")
        {
            Obj_Box hit_box = hitInfo.GetComponent<Obj_Box>();
            if (hit_box != null)
                hit_box.TakeDamage(damage);
        }

        if(hitInfo.tag == "Enemy")
        {
            Enemy_Skeleton hit_enemy = hitInfo.GetComponent<Enemy_Skeleton>();
            if (hit_enemy != null)
                hit_enemy.TakeDamage(damage);
        }


       
    }


    
}
