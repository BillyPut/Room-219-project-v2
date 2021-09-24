using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();

    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w") && (isGrounded == true) )
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 10f;    // give the player a velocity of 5 in the y axis

            }
        }

        rb.velocity = velocity;

    }

    void DoFaceLeft (bool faceleft)
    {
        if ( faceleft == true )
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }




    }




    void DoMove()
    {
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("a"))
        {
            velocity.x = -7;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            velocity.x = 7;
        }
        rb.velocity = velocity;

        if(velocity.x < -0.5)
        {
            DoFaceLeft(true);
        }
        if (velocity.x > 0.5f)
        {
            DoFaceLeft(false);
        }





    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }






    
}
