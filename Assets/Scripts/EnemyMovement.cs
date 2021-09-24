using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float enemySpeed;


    // Start is called before the first frame update
    void Start()
    {

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



       
        if (player.transform.position.x < -transform.position.x)
        {
            DoFaceLeft(true);
        }

        if (player.transform.position.x > transform.position.x)
        {
            DoFaceLeft(false);
        }







    }






}














