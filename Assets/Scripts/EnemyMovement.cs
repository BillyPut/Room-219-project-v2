using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float enemySpeed;
    private Animator anim;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
      
    }    
 
    // Update is called once per frame
    void Update()
    {
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














