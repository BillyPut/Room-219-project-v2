using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectileCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Platforms")
        {
            Destroy(gameObject);
        }





    }

}
