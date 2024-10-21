using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : WeaponBase
{
    BoxCollider2D collisor;
    SpriteRenderer spriteR;
    public int destroyChance;

    // Start is called before the first frame update
    void Start()
    {
        collisor = GetComponent<BoxCollider2D>();
        spriteR = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagable>(out IDamagable target))
        {
            target.TakeDamage(target.GetLife());
        }
        else
        {
            if (collision.CompareTag("XP"))
            {
                if (Random.Range(0, 100) <= destroyChance)
                    return;
            }
            Destroy(collision.gameObject);
        }        
    }
    public void PentagramEnd()
    {
        gameObject.SetActive(false);
    }
}
//collision = outro Objeto
//collisor = o próprio objeto
