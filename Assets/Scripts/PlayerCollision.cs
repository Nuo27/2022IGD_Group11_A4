using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static bool isKeyRedFlowerFound = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //if the player collides with the flower, the player collects the flower
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            //UI Say something here
            isKeyRedFlowerFound = true;
            Destroy(collision.gameObject);
        }
    }
}
