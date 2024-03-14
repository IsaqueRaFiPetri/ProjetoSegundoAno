using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{
    BoxCollider2D collisor;
    SpriteRenderer spriteR;
    public int destroyChance;

    // Start is called before the first frame update
    void Start()
    {
        collisor = GetComponent<BoxCollider2D>();
        spriteR = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Enemy":
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.TakeDamage(enemy.life);
                break;
            case "XP":
                if (Random.Range(0, 100) <= destroyChance)
                {
                    Destroy(collision.gameObject);
                }
                break;
        }
        
    }
    public void PentagramEnd()
    {
        gameObject.SetActive(false);
    }
}
//collision = outro Objeto
//collisor = o próprio objeto
