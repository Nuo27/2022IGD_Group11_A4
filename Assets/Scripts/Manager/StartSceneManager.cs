using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject StartScene;
    public GameObject ClicktoStartButton;
    public GameObject GameTitle;
    public GameObject StartMenu;
    public GameObject Levels;
    public GameObject SettingsMenu;
    public GameObject Credits;
    public static bool isTutorialDone;
    public static bool isReturningToMain;
    public GameObject tutorialReminder;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if(isTutorialDone){
            Debug.Log("Tutorial Done");
        }
        if(isReturningToMain){
            Debug.Log("Returned to Main");
        }
        // bool TestCheckMethod = LevelManager.checkCurrentLevelAccomplished(LevelManager.GetCurrentLevelIndex());
        // Debug.Log("Test Check Method: " + TestCheckMethod);
    }

    // Update is called once per frame
    void Update()
    {
        if(isReturningToMain || isTutorialDone){
            ReturnMainSetup();
        }
    }
    public void ClicktoStart()
    {
        LeanTween.moveLocalX(GameTitle, 150, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalX(StartMenu, 375, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.scale(ClicktoStartButton, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeOutQuad);
        Invoke("KillStartButton", 0.5f);
    }
    void KillStartClick()
    {
        Destroy(ClicktoStartButton);
    }
    public void StartButtonClick(){
        //animation back normal
        LeanTween.moveLocalX(GameTitle, 0, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalX(StartMenu, 0, 1.0f).setEase(LeanTweenType.easeOutQuad);
        Invoke("MoveTitleAndLevelsUp", 1.0f);
    }
    //Return Main Setup
    void ReturnMainSetup(){
        ClicktoStartButton.SetActive(false);
        GameTitle.transform.localPosition = new Vector3(0,100,0);
        Levels.transform.localPosition = new Vector3(0,180,0);
    }
    void MoveTitleAndLevelsUp(){
        LeanTween.moveLocalY(GameTitle, 100, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalY(Levels, 180, 1.0f).setEase(LeanTweenType.easeOutQuad);
    }
    public void SettingsButtonClick(){
        //StartMenu go back
        LeanTween.moveLocalX(StartMenu, 0, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalX(GameTitle, 200, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalX(SettingsMenu, 425, 1.0f).setEase(LeanTweenType.easeOutQuad);
    }
    public void BackButtonClick(){
        //SettingsMenu go back
        LeanTween.moveLocalX(SettingsMenu, 0, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalX(GameTitle, 150, 1.0f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.moveLocalX(StartMenu, 375, 1.0f).setEase(LeanTweenType.easeOutQuad);
    }
    //Levels.load
    public void TutorialStart(){
        SceneManager.LoadScene(5);
    }
    public void Level1(){
        if(isTutorialDone){
            //add code here to make replay notifcation appear
            LevelManager.isLevel1ObjectiveComplete = false;
            SceneManager.LoadScene(1);
        }
        else{
            LeanTween.scale(tutorialReminder, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutQuad);
            Invoke("CloseTutorialReminder", 2.0f);
        }
    }
    public void Level2(){
        if(isTutorialDone){
            LevelManager.isLevel2ObjectiveComplete = false;
            SceneManager.LoadScene(2);
        }
        else{
            LeanTween.scale(tutorialReminder, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutQuad);
            Invoke("CloseTutorialReminder", 2.0f);
        }
    }
    public void Level3(){
        if(isTutorialDone){
            LevelManager.isLevel3ObjectiveComplete = false;
            SceneManager.LoadScene(3);
        }
        else{
            LeanTween.scale(tutorialReminder, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutQuad);
            Invoke("CloseTutorialReminder", 2.0f);
        }
    }
    public void Level4(){
        if(isTutorialDone){
            LevelManager.isLevel4ObjectiveComplete = false;
            SceneManager.LoadScene(4);
        }
        else{
            LeanTween.scale(tutorialReminder, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutQuad);
            Invoke("CloseTutorialReminder", 2.0f);
        }
    }
    public void CloseTutorialReminder(){
        LeanTween.scale(tutorialReminder, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeOutQuad); 
     SceneManager.LoadScene(5);
    }
    //quit application
    public void Quit()
    {
        Application.Quit();
    }
}
