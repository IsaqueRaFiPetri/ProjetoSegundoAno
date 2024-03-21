using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[8];
    public GameObject enemy;
    float timer;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            RandomSpawn(2);
            timer = 0;
        }
    }
    void FixedSpawn(int enemyNumb)
    {
        foreach (Transform t in spawnPoints)
        {
            for (int i = 0; i < enemyNumb; i++)
            {
                Instantiate(enemy, t.position, enemy.transform.rotation);
            }
        }
    }
    void RandomSpawn(int enemyNumb)
    {
        for (int i = 0; i < enemyNumb; i++)
        {
            Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemy.transform.rotation);
        }
    }
}
