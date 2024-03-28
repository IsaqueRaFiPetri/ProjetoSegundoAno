using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int xpIncrease = 10, lifeMax = 100;
    int life;
    public static int level = 1;
    public static int xp, xpToNextLevel = 5;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        life = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void GainXp(int xpGain)
    {
        xp += xpGain;
        HUD.instance.SetXP();
        if(xp >= xpToNextLevel)
        {
            PlayerStats.level++;
            xp = 0;
            xpToNextLevel += PlayerStats.Instance.xpIncrease;
            HUD.instance.SetXP();
            HUD.instance.SetLevel();
            print(xp + "/" + xpToNextLevel);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Enemy>().damage;
        }
        HUD.instance.SetLife();
    }
    public int GetLife()
    {
        return life;
    }
}
