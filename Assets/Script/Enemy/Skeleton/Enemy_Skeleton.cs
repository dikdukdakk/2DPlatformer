using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : MonoBehaviour
{
    [Header("Enemy Properties")]
    public Animator animator_orc;
    public int health;
    public int damage = 1;
    public GameObject deathEffect;

    Rigidbody2D rb2D;
    BoxCollider2D box2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        box2D = GetComponent<BoxCollider2D>();
    }

    void LateUpdate()
    {
        //is Dead
        if (health <= 0)
            Dead();
    }

    void Dead()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        animator_orc.SetBool("isDead", true);
        rb2D.bodyType = RigidbodyType2D.Static;
        box2D.enabled = false;
        FindObjectOfType<Patrol>().enabled = false;
        StartCoroutine(w8DestroyObj());
    }

    public void TakeDamage (int dmg)
    {
        health -= dmg;
        if(health >= 1)
            StartCoroutine(w8Animate());

    }

    IEnumerator w8Animate()
    {
        animator_orc.SetBool("isTakeDamage", true);
        FindObjectOfType<Patrol>().speed = 0f;  
        yield return new WaitForSeconds(1);
        FindObjectOfType<Patrol>().speed = 1f;
        animator_orc.SetBool("isTakeDamage", false);
    }

    IEnumerator w8DestroyObj()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.tag == "Player")
            PlayerHeart.current.TakeDamage(damage);
    }
}
