using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy, IDamagable
{
    public int GetLife()
    {
        return life;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            if (Random.Range(0, 100) <= 25)
            {
                Instantiate(xp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
    }
}