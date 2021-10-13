using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float enemySpeed;
    private Animator anim;
    public float timeRemaining = 10;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }    
 
    // Update is called once per frame
    void Update()
    {
        DoMoveEnemy();
        
        float ex = transform.position.x;
        float px = player.transform.position.x;

        float dist = ex - px;
        
        if (dist > 3)
        {
            Helper.FlipSprite(gameObject, Left);
        }
        if (dist < -3)
        {
            Helper.FlipSprite(gameObject, Right);
        }

        

        if (dist < 20 && dist > -20)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        //  Helper.FacePlayer(player, gameObject);

    




    }

    void DoMoveEnemy()
    {
        bool result = Helper.DoRayCollisionCheck(gameObject);
        Vector2 velocity = rb.velocity;
        velocity.x = 0;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining < 2) 
        {
            velocity.x = -5f;
           
            
        }
        if (result == false)
        {
            timeRemaining = 10;
            velocity.x = 200f;



        }



        if (timeRemaining < 1)
        {
            timeRemaining = 10;
        }

        
      
        Helper.SetVelocity(velocity.x, 0, gameObject);
    }
    
   
    void SayHello()
    {
        print("Hello");
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        print("tag=" + col.gameObject.tag);

        if (col.gameObject.tag == "Bullet")
        {
            print("I've been hit by a bullet!");

        }
    }








}














