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
    void DoFaceLeft(bool faceleft)
    {
       if (faceleft == true)
       {
         transform.localRotation = Quaternion.Euler(0, 180, 0);
       }
       else
       {
         transform.localRotation = Quaternion.Euler(0, 0, 0);
       }




    }
    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x < transform.position.x)
        {
            DoFaceLeft(true);
        }
        else
        {
            DoFaceLeft(false);
        }

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




    }

    void SayHello()
    {
        print("Hello");
    }




}














