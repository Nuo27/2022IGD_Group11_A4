using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static bool isDoorOpen;
    private bool thisDoorOpen = false;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDoorOpen && !thisDoorOpen){
            StartCoroutine(OpenDoor());
            isDoorOpen = false;
            thisDoorOpen = true;
        }
    }
    IEnumerator OpenDoor(){
        float t = 0f;
        while(t < 1f){
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,90,0), t);
            yield return null;
        }
    }
}
