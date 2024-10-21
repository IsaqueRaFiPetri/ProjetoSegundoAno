using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AntiGravityObject : MonoBehaviour, IInteractable
{
    Rigidbody body;
    public float force = 1000;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    void IInteractable.Interact()
    {
        body.AddForce(new Vector3(0, force, 0));
    }
}
