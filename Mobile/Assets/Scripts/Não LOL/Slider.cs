using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Rigidbody2D body;
    Vector2 lastTouchPosition;
    public float distanceMin;
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
            //body.velocity = ((newTouchPosition - lastTouchPosition));

            //se quiser saber as posições certinhas
            if(newTouchPosition.x + distanceMin < lastTouchPosition.x - distanceMin)
            {
                print("ESQUERDA");
            }
            if (newTouchPosition.x - distanceMin > lastTouchPosition.x + distanceMin)
            {
                print("DIRETA");
            }
            if (newTouchPosition.y + distanceMin < lastTouchPosition.y - distanceMin)
            {
                print("BAIXO");
            }
            if (newTouchPosition.y - distanceMin > lastTouchPosition.y + distanceMin)
            {
                print("CIMA");
            }
        }
    }
}
