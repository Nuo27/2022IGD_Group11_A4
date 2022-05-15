using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ColSFX;
    public AudioClip AchieveSFX;
    public int color = -1;
    public int xcolor = 0;
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
        if (collision.gameObject.tag == "Level301")
        {
            UIManager.MessageText = "Red + blue = Violet.\nRed + Yellow = orange.\nRed + Green = Yellow.\nBlue + Green = Cyan.\nBlue + Yellow = Sliver.";
            UIManager.isPassingMessage = true;
        }
        if (collision.gameObject.tag == "Level302")
        {
            UIManager.MessageText = "May Xth I bought two new curtains.\nOne is yellow and one is blue.\nJune Xth I took three pictures of the house.\nThe one on the left is my room.\nThe middle one is my studio.\nAnd(the rest of the pages were torn off.)";
            UIManager.isPassingMessage = true;
        }
        if (collision.gameObject.tag == "Level303")
        {
            UIManager.MessageText = "You got a palette knife.\nThere is no color on the palette.\nBut you can pick color from the painting in the hallway.\nYou can only get one color at the same time.\nIf you use a wrong color,nothing will happened and the color will be used up.";
            UIManager.isPassingMessage = true;
            color += 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Level304")
        {
            if (color == 0)
            {
                UIManager.MessageText = "You got the Violet color.";
                UIManager.isPassingMessage = true;
                color = 1;
            }
            else
            {
                UIManager.MessageText = "";
            }
        }
        if (collision.gameObject.tag == "Level305")
        {
            if (color == 0)
            {
                UIManager.MessageText = "You got the Orange color.";
                UIManager.isPassingMessage = true;
                color = 2;
            }
            else
            {
                UIManager.MessageText = "";
            }
        }
        if (collision.gameObject.tag == "Level306")
        {
            if (color == 0)
            {
                UIManager.MessageText = "You got the Yellow color.";
                UIManager.isPassingMessage = true;
                color = 3;
            }
            else
            {
                UIManager.MessageText = "";
            }
        }
        if (collision.gameObject.tag == "Level307")
        {
            if (color == 0)
            {
                UIManager.MessageText = "You got the Cyan.";
                UIManager.isPassingMessage = true;
                color = 4;
            }
            else
            {
                UIManager.MessageText = "";
            }
        }
        if (collision.gameObject.tag == "Level308")
        {
            if (color == 0)
            {
                UIManager.MessageText = "You got the Sliver color.";
                UIManager.isPassingMessage = true;
                color = 5;
            }
            else
            {
                UIManager.MessageText = "";
            }
        }
        if (collision.gameObject.tag == "Level310")
        {
            if (color == 5)
            {
                UIManager.MessageText = "You paint it siliver.\nAnd it disappered.";
                UIManager.isPassingMessage = true;
                color = 0;
                xcolor += 1;
                Destroy(collision.gameObject);
            }
            if (color == -1)
            {
                UIManager.MessageText = "";
            }
            else
            {
                color = 0;
            }
        }
        if (collision.gameObject.tag == "Level311")
        {
            if (color == 4)
            {
                UIManager.MessageText = "You paint it Cyan.\nAnd it disappered.";
                UIManager.isPassingMessage = true;
                color = 0;
                xcolor += 1;
                Destroy(collision.gameObject);
            }
            if (color == -1)
            {
                UIManager.MessageText = "";
            }
            else
            {
                color = 0;
            }
        }
        if (collision.gameObject.tag == "Level312")
        {
            if (color == 1)
            {
                UIManager.MessageText = "You paint it Violet.\nAnd it disappered.";
                UIManager.isPassingMessage = true;
                color = 0;
                xcolor += 1;
                Destroy(collision.gameObject);
            }
            if (color == -1)
            {
                UIManager.MessageText = "";
            }
            else
            {
                color = 0;
            }
        }
        if (xcolor == 3)
        {
            LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
            xcolor = 0;
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
