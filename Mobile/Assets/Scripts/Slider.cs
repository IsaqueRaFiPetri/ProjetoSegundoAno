using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Rigidbody2D body;
    Vector2 lastTouchPosition;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            lastTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
       if (Input.GetButtonUp("Fire1"))
        {
            Vector2 newTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            body.velocity = ((newTouchPosition - lastTouchPosition));
        }
    }
}
