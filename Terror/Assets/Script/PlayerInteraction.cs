using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    Transform cam;
    public float handDistance = 3;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.position, cam.forward * handDistance, Color.blue);
        if (Physics.Raycast(cam.position, cam.forward, out hit, handDistance))
        {
            print(hit.collider.name);
        }
    }
}
