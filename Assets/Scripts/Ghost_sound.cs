using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ghost_sound : MonoBehaviour
{
    public AudioSource ghost;
    private bool ghost_appear;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ghost.Play();
        }
        
    }
}
