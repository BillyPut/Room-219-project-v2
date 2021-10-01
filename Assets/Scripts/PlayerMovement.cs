using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        if (isGrounded == false)
        {                      
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }

    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w") && (isGrounded == true) )
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 10f;   
                
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

        if (velocity.x > 0 || velocity.x < 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
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
