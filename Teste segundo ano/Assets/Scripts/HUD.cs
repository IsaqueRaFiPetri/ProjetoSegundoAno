using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public TMP_Text levelTxt;
    public Image xpBar, lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetLevel();
        SetXP();
        SetLife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel()
    {
        //levelTxt.text = "Lv "+PlayerStats.level+".";
        levelTxt.text = $"Lv {PlayerStats.level}";
    }
    public void SetLife()
    {
        lifeBar.fillAmount = (float)PlayerStats.Instance.GetLife() / (float)PlayerStats.Instance.lifeMax;
    }
    public void SetXP()
    {
        xpBar.fillAmount = (float)PlayerStats.xp / (float)PlayerStats.xpToNextLevel;
    }


}
