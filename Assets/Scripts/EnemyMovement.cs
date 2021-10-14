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
    private bool movingRight = true;
    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }    
 
    // Update is called once per frame
    void Update()
    {
     
        
        float ex = transform.position.x;
        float px = player.transform.position.x;

        float dist = ex - px;
        

        

        if (dist < 20 && dist > -20)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        //  Helper.FacePlayer(player, gameObject);


        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 7f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }



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














