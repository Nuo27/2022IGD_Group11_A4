using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    public GameObject promptBox;
    public TMPro.TextMeshProUGUI promptText1;
    public TMPro.TextMeshProUGUI promptText2;
    public TMPro.TextMeshProUGUI promptText3;
    public bool showPrompt = false;
    public GameObject OBJ;

    public static bool enableMouseInput = false;
    public static bool enableTutorialObjectives = false;
    private bool w;
    private bool a;
    private bool s;
    private bool d;
    private Vector3 NewPos;
    private bool temp = true;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("showPromptBox", 1f);
        setPromptText("Move around with WASD", "Hide", "Hide");
        OBJ.SetActive(false);
        enableMouseInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if press w
        if (Input.GetKeyDown(KeyCode.W))
        {
            w = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            a = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            s = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            d = true;
        }
        if(w&&a&&s&&d){
            
            if(temp){
                //find player and get the pos
                NewPos = GameObject.FindGameObjectWithTag("Player").transform.position;
                temp = false;
            }
            enableMouseInput = true;
            setPromptText("Well Done!", "Move with the mouse", "Hide");
            float distance = Vector3.Distance(NewPos,GameObject.FindGameObjectWithTag("Player").transform.position);
            if(distance >= 6f){
                setPromptText("Well Done!", "Well Done!", "Find and Touch the Red Flower");
                      if (OBJ!=null){
                  OBJ.SetActive(true);
                }     
            }
        }


    }
    private void setPromptText(string text, string text2, string text3){
        promptText1.text = text;
        promptText2.text = text2;
        promptText3.text = text3;
    }
    private void showPromptBox(){
        LeanTween.moveLocalX(promptBox, 0, 0.5f).setEaseInOutQuad();
    }
    private void hidePromptBox(){

    }
}
