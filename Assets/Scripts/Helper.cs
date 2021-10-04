using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{



    public static void FlipSprite( GameObject obj, bool dirLeft)
    {
        if (dirLeft == true )
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


    }
    
    public static void FacePlayer(GameObject object1, GameObject object2  )
    {
        
        float x1 = object1.transform.position.x;
        float x2 = object2.transform.position.x;
        float distance = x2 - x1;

        print(distance);

       
      







    }


}
