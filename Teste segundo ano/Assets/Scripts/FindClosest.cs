using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    public static FindClosest Instance;

    void Awake()
    {
        Instance = this;
    }

    public static void FindClosestEnemy()
    {
        float distanceToClosestEnemy =  Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - PlayerMoviment.posPlayer.transform.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(PlayerMoviment.posPlayer.transform.transform.position, closestEnemy.transform.position);
    }
}
//https://www.youtube.com/watch?v=YLE3v8bBnck