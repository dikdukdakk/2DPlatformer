using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public static PlayerMovement current;
    public Animator animator;

    private Rigidbody2D rb;

    float runSpeed = 25f;

    [Header("Movement")]
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public bool jump = false;
    public bool slash = false;
    //bool shootAir = false;

    public static int extraJumps = 1;

    [Header("Climning")]
    public float speed;
    public bool isClimbing;
    public float distance;
    public LayerMask whatIsLadder;
    

    private void Start()
    {
        current = this;
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        //Input On Keyboard
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("isSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            jump = true;
            CharacterController2D.current.m_Rigidbody2D.velocity = Vector2.up * CharacterController2D.current.m_JumpForce;
            extraJumps--;

            animator.SetBool("isJumping", true);

        } 
        if (Input.GetButtonDown("Z") && horizontalMove == 0) // Key Z
        {
            slash = true;    //เข้าแล้วไม่ยอมออก ถ้าโหลดท่ายังไม่เสด
            animator.SetBool("isSlashing_Idle", true); 
        }
        else if(Input.GetButtonDown("Z") && horizontalMove != 0)
        {
            slash = true;
           // horizontalMove = 0;
            animator.SetBool("isSlashing_Run", true);
        }
    }

    

    //Input On Button
    public void m_MoveLeftDown()
    {
        horizontalMove = -runSpeed;
    }

    public void m_MoveRightDown()
    {
        horizontalMove = runSpeed;
    }

    public void m_MoveLeftRightUp()
    {
        horizontalMove = 0;
    }

    public void m_Jump()
    {
        if (extraJumps > 0)
        {
            jump = true;
            CharacterController2D.current.m_Rigidbody2D.velocity = Vector2.up * CharacterController2D.current.m_JumpForce;
            extraJumps--;

           // animator.SetBool("isJumping", true);
        }

    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }


    public void m_Slashing()
    {
        if (horizontalMove == 0)
        {
            slash = true;
            animator.SetBool("isSlashing_Idle", true);
        }
        else
        {
            slash = true;
            animator.SetBool("isSlashing_Run", true);
        }
    }
    public void OnSlashing()
    {
        slash = false;
        Invoke("w8Animate", 0.25f);
    }

    void w8Animate()
    {
        animator.SetBool("isSlashing_Idle", false);
        animator.SetBool("isSlashing_Run", false);

       // animator.SetBool("isShooting_Air", false);
    }


    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime,jump, slash);
        jump = false;

        // animator.SetFloat("isSpeed", Mathf.Abs(horizontalMove));

       
    }


}