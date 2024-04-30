using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : WeaponBase
{
    public GameObject objToFire;

    public float minCool = 0.1f;
    public float maxCool = 2.0f;
    public Transform[] spawnPoints = new Transform[8];

    void Start()
    {
        StartCoroutine(SpawnMagic());
    }

    IEnumerator SpawnMagic()
    {
        while (true)
        {
            float cooldown = Random.Range(minCool, maxCool);
            yield return new WaitForSeconds(cooldown);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            Instantiate(objToFire, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
