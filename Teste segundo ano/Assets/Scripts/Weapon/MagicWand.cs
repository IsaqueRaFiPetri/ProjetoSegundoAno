using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWand : WeaponBase
{
    public int damage;
    public int speed;
    public GameObject objToFire;
    float timer;
    public float cooldown;

    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosest.FindClosestEnemy();
        if (timer == cooldown)
        {
            timer = 0;

        }
    }
}
