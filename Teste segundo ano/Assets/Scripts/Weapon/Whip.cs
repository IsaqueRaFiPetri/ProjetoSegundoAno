using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : WeaponBase
{
    public int damageMin, damegMax;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamagable>(out IDamagable target))
        {
            int finalDamage = Random.Range(damageMin, damegMax + 1);
            if (Random.Range(0, 100) <= 20)
            {
                finalDamage *= 2;
            }
            target.TakeDamage(finalDamage);
        }
    }
}
