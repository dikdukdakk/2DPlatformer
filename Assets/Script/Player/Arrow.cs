﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    public int dmg = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy_Skeleton orc = hitInfo.GetComponent<Enemy_Skeleton>();
        if (orc != null)
            orc.TakeDamage(dmg);

        Destroy(gameObject);
    }
}
