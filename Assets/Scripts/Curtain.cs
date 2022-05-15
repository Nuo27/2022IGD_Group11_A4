using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : Thing
{
    [SerializeField]
    private bool open = false;
    private float closeScale = 2.3f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (!open)
        {
            closeScale = transform.localScale.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnEDown()
    {
        if (open)
            gameObject.transform.localScale = new Vector3(closeScale,1,1);
        else
            gameObject.transform.localScale = Vector3.one;
        open = !open;
    }
}
