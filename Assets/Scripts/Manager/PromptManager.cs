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
    // Start is called before the first frame update
    void Start()
    {
        Invoke("showPromptBox", 1f);
        setPromptText("Mission1 Test", "Mission2 Test", "Mission3 Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setPromptText(string text, string text2, string text3){
        promptText1.text = text;
        promptText2.text = text2;
        promptText3.text = text3;
    }
    private void showPromptBox(){
        LeanTween.moveLocalX(promptBox, 0, 0.5f).setEaseInOutQuad();
    }
}
