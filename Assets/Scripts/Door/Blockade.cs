using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : MonoBehaviour
{
   [SerializeField] private Animator TheBlockade = null;
    [SerializeField] private bool openTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                TheBlockade.Play("Remove block", 0, 0.0f);
                gameObject.SetActive(false);
            }
            
        }
    }
}
