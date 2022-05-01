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
    public TMPro.TextMeshProUGUI AccomplishedObjectiveText;
    public GameObject minimap;
    public TMPro.TextMeshProUGUI ResetText;
    void Start()
    {
        //if restarting level, reset everthing
        AccomplishedObjectiveText.text = SetAccomplishedObjectiveText(LevelManager.GetCurrentLevelIndex());
        ObjectiveText.text = SetObjectiveText(LevelManager.GetCurrentLevelIndex());
        CurrentLevelText.text = SetCurrentLevelText(LevelManager.GetCurrentLevelIndex());
        Invoke("KillLevelStartMessages", 3f);
        
        //DontDestroyOnLoad(gameObject);
    }
    void KillLevelStartMessages(){
        LevelMessageHolder.SetActive(false);
        ControlMessageHolder.SetActive(false);
        minimap.SetActive(true);
        //Destroy(LevelMessageHolder);
    }
    // Update is called once per frame
    void Update()
    {
        if(LevelManager.checkCurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex())){
            Debug.Log("Level Objective Done");
            callOutMessage(); 
        }
        if(PlayerMovement.playerPosY < -10){
            ResetText.text = "You died...restarting level in 3 sec...";
            Invoke("Restartinglevel", 3f);
        }
        else{
            ResetText.text = "";
        }

    }
    void Restartinglevel(){
        LevelManager.reloadLevel = true;
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
    string SetAccomplishedObjectiveText(int CurrentLevelIndex){
        switch(CurrentLevelIndex){
            case 1:
                return "Level 1 Accomplished Objective text";
            case 2:
                return "Level 2 Accomplished Objective text";
            case 3:
                return "Level 3 Accomplished Objective text";
            case 4:
                return "Level 4 Accomplished Objective text";
            case 5:
                return "Level Tutorial Objective Accomplished";
            case 6:
                return "Level Test Objective Accomplished: New memory gained; CG now will load";
            default:
                return "";
        }
    }
    public void OnClickTutorialDone(){
        LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        SceneManager.LoadScene(0);
    }
    public void onClickRestart(){
        
        SceneManager.LoadScene(LevelManager.GetCurrentLevelIndex());
    }
    public void OnClickReturnMain(){
        
        if(!StartSceneManager.isReturningToMain){
            StartSceneManager.isReturningToMain = true;
        }
        SceneManager.LoadScene(0);
    }
}
