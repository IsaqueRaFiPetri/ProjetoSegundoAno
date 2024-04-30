using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class MagicWandFire : MonoBehaviour
{
    public GameObject fireToFire;
    Rigidbody2D fireBody;

    public int damageMin, damegMax;
    public float startForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        fireBody = GetComponent<Rigidbody2D>();
        fireBody.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int finalDamage = Random.Range(damageMin, damegMax + 1);
            if (Random.Range(0, 100) <= 20)
            {
                finalDamage *= 2;
            }
            collision.GetComponent<Enemy>().TakeDamage(finalDamage);
            print(finalDamage);

            if (collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}
