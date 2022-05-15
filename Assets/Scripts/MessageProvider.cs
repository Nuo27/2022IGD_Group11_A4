using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageProvider : MonoBehaviour
{
    [SerializeField]
    static private TMP_Text textMeshPro;
    [SerializeField]
    private string msg;
    static bool showing = false;
    // Start is called before the first frame update
    void Start()
    {
        if(textMeshPro==null)
            textMeshPro = GameObject.Find("MsgShower").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEDown()
    {
        textMeshPro.text = msg;
    }
    public void OnEDown(string msg)
    {
        textMeshPro.text = msg;
    }
}
