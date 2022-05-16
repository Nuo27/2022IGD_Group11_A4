using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingSystem : MonoBehaviour
{
    public GameObject collectText;
    public static int theScore;
    public GameObject finalTrigger;

    private void Awake() {
        theScore = 0;
    }
    void Update()
    {
        collectText.GetComponent<Text>().text = "Diaries Collected: " + theScore;
        if (theScore == 5){
            finalTrigger.SetActive(true);
        }
    }

}
