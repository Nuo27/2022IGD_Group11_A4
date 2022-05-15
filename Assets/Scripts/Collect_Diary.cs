using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Diary : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        CollectingSystem.theScore += 1;
    }
}
