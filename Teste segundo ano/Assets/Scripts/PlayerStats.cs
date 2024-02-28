using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int nivel;
    [HideInInspector]public int xp, xpToNextLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void GainXp(PlayerStats status, int xpGain)
    {
        status.xp += xpGain;
        if(status.xp >= status.xpToNextLevel)
        {
            PlayerStats.nivel++;
        }
    }
}
