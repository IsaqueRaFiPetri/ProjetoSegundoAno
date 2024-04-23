using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int xpIncrease = 10, lifeMax = 100;
    int life;
    public static int luck;
    public static int level = 1;
    public static int xp, xpToNextLevel = 5;
    public Transform weapons;
    
    public UnityEvent OnLevelUp;
    public UnityEvent OnPause, OnUnpause;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        life = lifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
                OnUnpause.Invoke();
            }
            else
            {
                Time.timeScale = 0;
                OnPause.Invoke();
            }
        }
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
            PlayerStats.Instance.OnLevelUp.Invoke();
            WeaponsChoiceMenu.instance.ChooseWeapons();
            //print(xp + "/" + xpToNextLevel);
        }
    }

    public void SetPause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Enemy>().damage;
            HUD.instance.SetLife();
            if(life <= 0) 
            {
                gameObject.SetActive(false);
            }
        }
        
    }
    public int GetLife()
    {
        return life;
    }
}
