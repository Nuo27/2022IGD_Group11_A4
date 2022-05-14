using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static bool isLevel1ObjectiveComplete;
    public static bool isLevel2ObjectiveComplete;
    public static bool isLevel3ObjectiveComplete;
    public static bool isLevel4ObjectiveComplete;
    public static bool isTestObjectiveComplete;
    public static bool reloadLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current level index: " + GetCurrentLevelIndex());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(Cursor.lockState == CursorLockMode.Locked){
                Cursor.lockState = CursorLockMode.None;
            }
            else{
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if(reloadLevel){
            reloadLevel = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //get current level index
    public static int GetCurrentLevelIndex(){
        return SceneManager.GetActiveScene().buildIndex;
    }
    public static bool checkCurrentLevelAccomplished(int CurrentLevelIndex){
        switch(CurrentLevelIndex){
            case 0:
                return false;
            case 1:
                return isLevel1ObjectiveComplete;
            case 2:
                return isLevel2ObjectiveComplete;
            case 3:
                return isLevel3ObjectiveComplete;
            case 4:
                return isLevel4ObjectiveComplete;
            case 5:
                return StartSceneManager.isTutorialDone;
            case 6:
                return isTestObjectiveComplete;
            default:
                return false;

        }
    }
    public static void CurrentLevelAccomplished(int CurrentLevelIndex){
        switch(CurrentLevelIndex){
            case 1:
                isLevel1ObjectiveComplete = true;
                break;
            case 2:
                isLevel2ObjectiveComplete = true;
                break;
            case 3:
                isLevel3ObjectiveComplete = true;
                break;
            case 4:
                isLevel4ObjectiveComplete = true;
                break;
            case 5:
                StartSceneManager.isTutorialDone = true;
                break;
        }
    }
    public static void SetCurrentLevelAccomplished(int CurrentLevelIndex, bool isAccomplished){
        switch(CurrentLevelIndex){
            case 1:
                isLevel1ObjectiveComplete = isAccomplished;
                break;
            case 2:
                isLevel2ObjectiveComplete = isAccomplished;
                break;
            case 3:
                isLevel3ObjectiveComplete = isAccomplished;
                break;
            case 4:
                isLevel4ObjectiveComplete = isAccomplished;
                break;
            case 5:
                StartSceneManager.isTutorialDone = isAccomplished;
                break;
        }
    }
    
    
}
