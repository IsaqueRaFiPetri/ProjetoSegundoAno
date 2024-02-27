using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    Rigidbody2D body;
    Transform posPlayer;
    bool isMagnetized;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMagnetized)
        {
            body.velocity = ((posPlayer.position - transform.position) * 2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Magnetic"))
        {
            posPlayer = collision.transform;
            isMagnetized = true;
        }
    }
}
