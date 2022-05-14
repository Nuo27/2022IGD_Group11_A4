using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public Animator anim;
    public static bool LoadLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // if(LoadLevel){
        //     anim.SetBool("SceneLoad",true);
        //     LoadLevel = false;
        //     Invoke("ShowTheScene",2f);
        // }
        anim.SetBool("SceneLoad",LoadLevel);
    }
    void ShowTheScene(){
        anim.SetBool("SceneLoad",false);
    }
}
