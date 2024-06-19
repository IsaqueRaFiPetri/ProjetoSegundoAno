using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public UnityEvent OnInteractionEffected;
    public static PlayerInteraction instance;
    Transform cam;
    public float handDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.position, cam.forward * handDistance, Color.blue);
        if (Physics.Raycast(cam.position, cam.forward, out hit, handDistance))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
                //print(hit.collider.name);
            }
        }
    }
}
