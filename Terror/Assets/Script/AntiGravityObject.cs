using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AntiGravityObject : InteractableObject
{
    Rigidbody body;
    public float force = 1000;

    protected override void Interact()
    {
        //AddComponent<Rigidbody>();
        body.AddForce(new Vector3(0, force, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
