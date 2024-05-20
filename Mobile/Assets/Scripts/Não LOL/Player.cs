using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public Joystick joystick;
    Rigidbody2D body;
    float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        body.velocity = new Vector2(horizontal, vertical) * 5;
        //para mudar a gravidade
        /*if (Input.GetMouseButtonDown(0))
        {

        }
        if(Input.GetButtonDown("Fire1")) 
        {
            body.gravityScale *= -1;
            // se tivesse sito usado apenas o == -1, só poderia ser usado uma vez, se multiplicado, pode ser usasdo diversas vezes
        }*/

    }
}
