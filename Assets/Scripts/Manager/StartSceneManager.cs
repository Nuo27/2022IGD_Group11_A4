using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Manager;
    void Start()
    {
        DontDestroyOnLoad(Manager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClicktoStart()
    {
        SceneManager.LoadScene(1);
    }
}
