using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool isDoorOpened;
    bool doorClose = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoorOpened && doorClose){
            StartCoroutine(OpenDoor());
            //transform.Rotate(0, 90, 0);
            isDoorOpened = false;
            doorClose = false;
        }
    }
    IEnumerator OpenDoor(){
        //rotate the door by lerping
        float t = 0.0f;
        while(t < 1.0f){
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), t);
            yield return null;
        }
    }
}
