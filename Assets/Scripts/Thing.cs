using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [SerializeField]
    protected AudioClip audioClip;
    protected AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
    }
    protected virtual void Start()
    {
        gameObject.tag = "Thing";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnEDown()
    {

    }
}
