using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger_diff : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                myDoor.Play("door_open_diff", 0, 0.0f);
                gameObject.SetActive(false);
            }
            
        }
    }
}
