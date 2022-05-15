using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Thing
{
    [SerializeField]
    private float dis = 0.2f;
    [SerializeField]
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
        if (open)
        {
            audioSource.Play();
            gameObject.transform.Translate(-Vector3.forward * dis,Space.Self);
        }
        else
        {
            audioSource.Play();
            gameObject.transform.Translate(Vector3.forward * dis, Space.Self);
        }
        open = !open;
    }
}
