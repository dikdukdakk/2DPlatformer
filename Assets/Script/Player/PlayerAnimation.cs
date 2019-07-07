using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        animator.SetFloat("isSpeed", Mathf.Abs(PlayerMovement.current.horizontalMove));

        if (PlayerMovement.current.jump == true)
            animator.SetBool("isJumping", true);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
}
