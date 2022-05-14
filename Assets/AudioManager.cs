using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioClip backgroundMusic;
    public AudioClip JumpSFX;

    public AudioSource audioSource;
    public static bool playJumpSFX;
    private void Awake() {
        //dont destroy on load
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
    }


}
