using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header("Spike Properties")]
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player")
            PlayerHeart.current.TakeDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.tag == "Player")
            PlayerHeart.current.TakeDamage(damage);
    }
}
