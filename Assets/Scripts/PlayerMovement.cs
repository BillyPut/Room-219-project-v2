using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;
    public GameObject projectilePrefab;
   


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
                velocity.y = 12f;   
                
            }

           
        }
       
       


        rb.velocity = velocity;

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



        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, Left);
        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Right);
        }





        if (Input.GetKeyDown("z") && (transform.rotation.x == 0) )
        {
            Helper.MakeBullet(projectilePrefab, transform.position.x + 8, transform.position.y + 5, 50.0f, 0);

        }
        if (Input.GetKeyDown("z") && (transform.rotation.x > 0) )
        {
            Helper.MakeBullet(projectilePrefab, transform.position.x - 8, transform.position.y + 5, -50.0f, 0);
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
