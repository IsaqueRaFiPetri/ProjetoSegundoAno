using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : WeaponBase
{
    public int damage;
    public int speed;
    public GameObject crossItem;
    public Rigidbody2D body;
    private float weaponCooldown;
   
    // Start is called before the first frame update
    void Start()
    {
        weaponCooldown = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponCooldown == 2.0f)
        {
            FindClosest.FindClosestEnemy();
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(crossItem);
    }
}
