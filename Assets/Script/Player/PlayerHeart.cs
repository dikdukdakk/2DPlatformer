using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    public static PlayerHeart current;
    
    [Header("Player Properties")]
    public int heart;
    public bool hurt = false;
    public Animator animator;
    public PlayerMovement playermovement;
    public GameObject hurtfx;
    
    int playerLayer, enemyLayer;
    BoxCollider2D box2D;

    private void Start()
    {
        current = this;
        box2D = GetComponent<BoxCollider2D>();
        playerLayer = this.gameObject.layer;
        enemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false); //ไม่สน collision ชั่วขณะ
    }

    void LateUpdate()
    {
        if(heart <= 0)
        {
            animator.SetBool("isDead", true);
            playermovement.enabled = false;
            heart = 0;
            hurt = true;
            GameManager.current.GameOver();

        }    
    }

    public void TakeDamage(int damage)
    {
        heart -= damage;
        if (heart > 0)
            StartCoroutine(w8Animatehurt());
    }

    IEnumerator w8Animatehurt()
    {
        Instantiate(hurtfx, transform.position, transform.rotation);

        animator.SetBool("isTakeDamage", true);
        hurt = true;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isTakeDamage", false);
        hurt = false;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);

        
    }

   

}
