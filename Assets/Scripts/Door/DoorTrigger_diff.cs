using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class DoorTrigger_diff : MonoBehaviour
{
    [SerializeField] private Animator myDoor;
    public AudioSource door_audio;
    private bool door_triggered_diff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myDoor.Play("door_open_diff", 0, 0.0f);
            door_audio.Play();
            Invoke("disable_gameobject", 1.5f);
        }
        
    }
    void disable_gameobject(){
        gameObject.SetActive(false);
    }
}
