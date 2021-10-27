using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class MonsterMovement : MonoBehaviour
{

    public GameObject player;
    public float enemySpeed;
    private Animator anim;
    public float timeRemaining = 10;
    private bool movingRight = true;
    public Transform groundDetection;
    public GameObject projectileAttack;

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




        if (dist < 10 && dist > -10)
        {
            anim.SetBool("Attack", true);
            enemySpeed = 0;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            anim.SetBool("Attack", false);
            enemySpeed = 2;
        }

        //  Helper.FacePlayer(player, gameObject);


        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
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




    void SwordAttack()
    {

        float ex = transform.position.x;
        float px = player.transform.position.x;

        float dist = ex - px;

        if (dist < (10) && (dist > 0))
        {
            Helper.MakeBullet(projectileAttack, transform.position.x - 1.5f, transform.position.y + 0.5f, -10.0f, 0);

        }
        if (dist > (-10) && (dist < 0))
        {
            Helper.MakeBullet(projectileAttack, transform.position.x + 1.5f, transform.position.y + 0.5f, 10.0f, 0);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        print("tag=" + col.gameObject.tag);

        if (col.gameObject.tag == "Bullet")
        {
            print("I've been hit by a bullet!");

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }


    }






}


