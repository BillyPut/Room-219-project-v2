using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Helper.FlipSprite(gameObject, true);
        }
        if (dist < -3)
        {
            Helper.FlipSprite(gameObject, false);
        }

        

        if (dist < 20 && dist > -20)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }


        Helper.FacePlayer(player, gameObject);






    }

    void SayHello()
    {
        print("Hello");
    }




}














