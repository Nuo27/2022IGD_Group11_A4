using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public AudioClip backgroundMusic;
    public AudioClip JumpSFX;

    public AudioSource audioSource;
    public AudioMixer masterMixer;
    public static bool playJumpSFX;
    private void Awake() {
        //dont destroy on load

        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

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
    public void ApplyMasterVolume(float volume)
    {
        masterMixer.SetFloat("MasterVolume", volume);
    }


}
