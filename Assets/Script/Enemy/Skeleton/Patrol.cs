using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public static Patrol current;
    public float speed;
    public float distrance = 2f;

    private void Start()
    {
        current = this;   
    }

    private bool moveingRight = true;

    public Transform groundDetection;

    private void LateUpdate()
    {
        Physics2D.IgnoreLayerCollision(3,3, true);

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distrance);
        if(groundInfo.collider == false)
        {
            if (moveingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveingRight = true;
            }
        }
        
    }
}
