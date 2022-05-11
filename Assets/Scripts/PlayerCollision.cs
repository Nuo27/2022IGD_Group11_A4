using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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
            Destroy(collision.gameObject);
            LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());;
        }
        if(collision.gameObject.tag == "OpenableDoor"){
            Door.isDoorOpen = true;
        }
        if(collision.gameObject.tag == "Level1O1"){
            collision.gameObject.SetActive(false);
            PlayerMovement.canJump = true;
            UIManager.isPassingMessage = true;
        }
    }
}
