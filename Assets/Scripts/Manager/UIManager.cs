using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LevelMessageHolder;
    public GameObject MessageHolder;
    void Start()
    {
        Invoke("KillLevelStartMessages", 3f);
        DontDestroyOnLoad(gameObject);
    }
    void KillLevelStartMessages(){
        LevelMessageHolder.SetActive(false);
        //Destroy(LevelMessageHolder);
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerCollision.isKeyRedFlowerFound){
            Debug.Log("Key Red Flower Found");
            callOutMessage();
            PlayerCollision.isKeyRedFlowerFound = false;
        }
    }
    private void callOutMessage(){
        MessageHolder.SetActive(true);
        Invoke("killMessage", 2.0f);
    }
    void killMessage(){
        MessageHolder.SetActive(false);
    }
    public void OnClickTutorialDone(){
        StartSceneManager.isTutorialDone = true;
        SceneManager.LoadScene(0);
    }
    public void OnClickReturnMain(){
        if(!StartSceneManager.isReturningToMain){
            StartSceneManager.isReturningToMain = true;
        }
        SceneManager.LoadScene(0);
    }
}
