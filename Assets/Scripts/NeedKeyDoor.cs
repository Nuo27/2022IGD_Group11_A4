using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedKeyDoor : MonoBehaviour
{
    [SerializeField]
    private Key.KeyType needTpye;
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
        if (Player.singleton.keys[(int)needTpye] != (int)needTpye+1)
            GetComponent<MessageProvider>().OnEDown();
        else
        {
            Player.singleton.keys[(int)needTpye] = 0;
            gameObject.tag = "Thing";
            gameObject.AddComponent<Door>();
            GetComponent<MessageProvider>().OnEDown("Successfully unlocked");
        }
    }
}
