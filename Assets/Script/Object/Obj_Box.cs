using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Box : MonoBehaviour
{
    int hitpoint = 1;

    void LateUpdate()
    {
        if (hitpoint <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hitpoint -= damage;
        
        
        /*int randomItem = Random.Range(1, 3);
        switch(randomItem)
            case 1: Instantiate
                break;
            case 2: Instantiate
                break;
            case 3: 
                break;*/
    }
}
