using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LevelMessageHolder;
    public GameObject ControlMessageHolder;
    public GameObject MessageHolder;
    public TMPro.TextMeshProUGUI ObjectiveText;
    public TMPro.TextMeshProUGUI CurrentLevelText;
    void Start()
    {
        
        ObjectiveText.text = SetObjectiveText(LevelManager.GetCurrentLevelIndex());
        CurrentLevelText.text = SetCurrentLevelText(LevelManager.GetCurrentLevelIndex());
        Invoke("KillLevelStartMessages", 3f);
        DontDestroyOnLoad(gameObject);
    }
    void KillLevelStartMessages(){
        LevelMessageHolder.SetActive(false);
        ControlMessageHolder.SetActive(false);
        //Destroy(LevelMessageHolder);
    }
    // Update is called once per frame
    void Update()
    {

        if(LevelManager.checkCurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex())){
            Debug.Log("Level Objective Done");
            callOutMessage(); 
        }
    }
    private void callOutMessage(){
        MessageHolder.SetActive(true);
        Invoke("killMessage", 2.0f);
    }
    void killMessage(){
        Destroy(MessageHolder);
        //MessageHolder.SetActive(false);
    }
    string SetObjectiveText(int CurrentLevelIndex){
        switch(CurrentLevelIndex){
            case 1:
                return "Level 1 Objective text";
            case 2:
                return "Level 2 Objective text";
            case 3:
                return "Level 3 Objective text";
            case 4:
                return "Level 4 Objective text";
            case 5:
                return "Level Tutorial Objective text";
            case 6:
                return "Find the red Flower";
            default:
                return "";
        }
    }
    string SetCurrentLevelText(int CurrentLevelIndex){
        switch(CurrentLevelIndex){
            case 1:
                return "Level 1";
            case 2:
                return "Level 2";
            case 3:
                return "Level 3";
            case 4:
                return "Level 4";
            case 5:
                return "Level Tutorial";
            case 6:
                return "level Test";
            default:
                return "";
        }
    }
    public void OnClickTutorialDone(){
        LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        SceneManager.LoadScene(0);
    }
    public void OnClickReturnMain(){
        if(!StartSceneManager.isReturningToMain){
            StartSceneManager.isReturningToMain = true;
        }
        SceneManager.LoadScene(0);
    }
}
