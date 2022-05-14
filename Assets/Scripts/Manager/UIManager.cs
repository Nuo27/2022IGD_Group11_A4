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
    public bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject Pause;
    public GameObject Settings;
    
    void Start()
    {
        //if restarting level, reset everthing
        AccomplishedObjectiveText.text = SetAccomplishedObjectiveText(LevelManager.GetCurrentLevelIndex());
        ObjectiveText.text = SetObjectiveText(LevelManager.GetCurrentLevelIndex());
        CurrentLevelText.text = SetCurrentLevelText(LevelManager.GetCurrentLevelIndex());
        Invoke("KillLevelStartMessages", 5f);
        
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
            LevelManager.SetCurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex(), false);
            //Invoke("returnMain",3f);
            Invoke("OnClickReturnMain",3f);
            
        }
        if(PlayerMovement.playerPosY < -10){
            ResetText.text = "You died...restarting level in 3 sec...";
            Invoke("Restartinglevel", 3f);
        }
        else{
            ResetText.text = "";
        }
        if(!isGamePaused && Input.GetKeyDown(KeyCode.R)){
            isGamePaused = true;
            ActivePauseMenu();
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
        //Destroy(MessageHolder);
        MessageHolder.SetActive(false);
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
                return "TRY TO MOVE YOUR CHARACTER, and Find the Red Flower";
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
            default:
                return "";
        }
    }
    string SetAccomplishedObjectiveText(int CurrentLevelIndex){
        switch(CurrentLevelIndex){
            case 1:
                return "Level 1 Accomplished Objective text" + "Return to Main in 3 sec...";
            case 2:
                return "Level 2 Accomplished Objective text" + "Return to Main in 3 sec...";
            case 3:
                return "Level 3 Accomplished Objective text" + "Return to Main in 3 sec...";
            case 4:
                return "Level 4 Accomplished Objective text" + "Return to Main in 3 sec...";
            case 5:
                return "Level Tutorial Objective Accomplished" + "Return to Main in 3 sec...";
            default:
                return "";
        }
    }
    public void OnClickTutorialDone(){
        LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        Invoke("returnMain",3f);
    }
    public void onClickRestart(){
        
        SceneManager.LoadScene(LevelManager.GetCurrentLevelIndex());
    }
    public void onClickTestObjectiveAccomplished(){
        LevelManager.CurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        Invoke("returnMain",3f);
    }
    void returnMain(){
        SceneManager.LoadScene(0);
    }
    public void OnClickReturnMain(){
        
        if(!StartSceneManager.isReturningToMain){
            StartSceneManager.isReturningToMain = true;
        }
        SceneManager.LoadScene(0);
    }
    void ActivePauseMenu(){
        pauseMenu.SetActive(true);
        LeanTween.moveLocalX(Pause, 0, 1f);
        PlayerMovement.isFreeze = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnClickResume(){
        pauseMenu.SetActive(false);
        LeanTween.moveLocalX(Pause, -1300, 1f);
        isGamePaused = false;
        PlayerMovement.isFreeze = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnClickSetting(){
        LeanTween.moveLocalX(Settings, 0, 1f);
        LeanTween.moveLocalX(Pause, -450, 1f);
    }
    public void OnClickSettingsBack(){
        LeanTween.moveLocalX(Settings, -450, 1f);
        LeanTween.moveLocalX(Pause, 0, 1f);
    }


}
