using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.Events;

public class WeaponsChoiceMenu : MonoBehaviour
{
    public TMP_Text[] weaponName = new TMP_Text[4];
    GameObject[] choicedWeapons = new GameObject[4];
    public UnityEvent OnLuck;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> weapons = Database.Instance.weapons.ToList();
        for(int i = 0; i < weaponName.Length; i++)
        {
            int randomNumber = Random.Range(0, weapons.Count);
            choicedWeapons[i] = weapons[randomNumber];
            weapons.RemoveAt(randomNumber);
            weaponName[i].text = choicedWeapons[i].name;
            if(i == 2)
            {
                if(Random.Range(0,100) < 1 - 1/PlayerStats.luck)
                {
                    OnLuck.Invoke();
                }
                else
                {
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
