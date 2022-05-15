using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ColSFX;
    public AudioClip AchieveSFX;
    private bool gotJump = false;
    //if the player collides with the flower, the player collects the flower
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        }
        if(collision.gameObject.tag == "OpenableDoor"){
            collision.gameObject.GetComponent<AudioSource>().Play();
            Door.isDoorOpen = true;
            //change the tag to untagged to prevent the door from opening again
            collision.gameObject.tag = "Untagged";
        }
        if(collision.gameObject.tag == "Level1O1"){
            ColSFX.clip = AchieveSFX;
            ColSFX.Play();
            collision.gameObject.SetActive(false);
            PlayerMovement.canJump = true;
            gotJump = true;
            UIManager.MessageText = "You got the jump force, go find the jump floor";
            UIManager.isPassingMessage = true;
        }
        
        
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "Level1O2"){
            collision.gameObject.SetActive(false);
            SceneTransition.LoadLevel = true;
            // UIManager.MessageText = "Ah..Why I am so dizzy...";
            // UIManager.isPassingMessage = true;
            LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        }
        if(collision.gameObject.tag == "Level2O1"){
            collision.gameObject.SetActive(false);
            
            SceneTransition.LoadLevel = true;
            // UIManager.MessageText = "Ah..Why I am so dizzy...";
            // UIManager.isPassingMessage = true;
            LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        }
        if(collision.gameObject.tag == "LetsJump"){
            if(SecretVase.AchieveVase){
                if(gotJump){
                    UIManager.MessageText = "Step on it and .. ready to jump!";
                    UIManager.isPassingMessage = true;
                }
                else{
                    UIManager.MessageText = "You need to get the jump force first";
                    UIManager.isPassingMessage = true;
                }    
            }
                
            else{
                print("You need to find the vase first");
                UIManager.MessageText = "To enter this secret door, You need to find the vase first";
                UIManager.isPassingMessage = true;
            }
        }

    }
}
