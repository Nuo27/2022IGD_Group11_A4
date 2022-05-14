using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    // Start is called before the first frame update
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
