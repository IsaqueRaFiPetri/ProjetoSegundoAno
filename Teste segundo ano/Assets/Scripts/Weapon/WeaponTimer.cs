using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class WeaponTimer : MonoBehaviour
{
    public UnityEvent OnTimerAttack;
    //public GameObject weapon;
    public float timeToActivate;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Activate());

        //InvokeRepeating("ActiveWeapon", 0, timeToActivate);
    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;
        if(timer >= timeToActivate)
        {
            ActiveWeapon();
            timer = 0;   
        }*/
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        ActiveWeapon();
        StartCoroutine(Activate());
    }

    void ActiveWeapon()
    {
        OnTimerAttack.Invoke();
        //weapon.SetActive(true);
    }    
}
//passar uma _string_ � passivel de erro