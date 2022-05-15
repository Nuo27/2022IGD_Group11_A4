using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public enum KeyType { One,Two}
    [SerializeField]
    private KeyType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEDown()
    {
        ++Player.singleton.keys[(int)type];
        GetComponent<MessageProvider>().OnEDown();
        Destroy(gameObject);
    }
}
