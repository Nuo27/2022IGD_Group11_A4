using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Thing
{
    private bool open = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnEDown()
    {
        if(open)
            gameObject.transform.Rotate(Vector3.up, -90, Space.Self);
        else
            gameObject.transform.Rotate(Vector3.up, 90, Space.Self);
        open = !open;
    }
}
