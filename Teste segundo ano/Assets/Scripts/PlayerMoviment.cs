using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 5;
    float horizontal;
    float vertical;

    public Transform weapon;
    public static Transform posPlayer;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        posPlayer = transform;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()                      //atualiza de acordo com a capacidade do computador
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0) 
        {
            direction = horizontal;
        }
        weapon.localScale = new Vector2(direction, weapon.localScale.y);
    }

    private void FixedUpdate()          //atualiza a taxa fixa
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
