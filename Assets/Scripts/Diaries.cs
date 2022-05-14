using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Diaries : MonoBehaviour
{   public GameObject Diary;
    // Start is called before the first frame update
    void Start()
    {
        Diary.SetActive(false);
    }
    void OnTriggerEnter(Collider other){
        if (other.tag =="Player"){
            Diary.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other){
        Diary.SetActive(false);
    }
}
