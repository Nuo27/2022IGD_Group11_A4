using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Thing nowThing;
    [SerializeField]
    private GameObject showObj;
    [SerializeField]
    private float distance = 5;
    static public Player singleton;
    [SerializeField]
    public int[] keys=new int[2] { 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        if (singleton == null)
            singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Vector3.zero), Camera.main.transform.forward*distance, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            if(hit.collider.tag == "Thing")
            {
                Show();
                nowThing = hit.collider.GetComponent<Thing>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nowThing.OnEDown();
                }
            }
            else if(hit.collider.tag == "Message")
            {
                //Debug.Log(hit.collider.name);
                Show();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<MessageProvider>().OnEDown();
                }
            }
            else if (hit.collider.tag == "Key")
            {
                //Debug.Log(hit.collider.name);
                Show();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Key>().OnEDown();
                }
            }
            else if (hit.collider.tag == "NeedKey")
            {
                //Debug.Log(hit.collider.name);
                Show();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<NeedKeyDoor>().OnEDown();
                }
            }
        }
        else
        {
            Hide();
            nowThing = null;
        }
    }
    private void Show()
    {
        showObj.SetActive(true);
    }
    private void Hide()
    {
        showObj.SetActive(false);
    }
}
