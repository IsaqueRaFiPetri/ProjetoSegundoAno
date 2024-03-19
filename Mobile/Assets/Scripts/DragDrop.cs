using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]  
public class DragDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        finalPosition.z = 0;
        transform.position = finalPosition;
    }
}
