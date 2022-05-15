using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    public AudioSource door_audio;
    private bool door_triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            myDoor.Play("door_open", 0, 0.0f);
            door_audio.Play();
            Invoke("disable_gameobject", 1.5f);
        }
        
    }
    void disable_gameobject(){
        gameObject.SetActive(false);
    }
}
