using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    public int life;
    public float speed;
    protected Rigidbody2D body;
    public GameObject xp;
    public bool garliczed;

    public void Moviment()
    {
        body.velocity = (PlayerMoviment.posPlayer.position - transform.position) * speed /10;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            if(Random.Range(0,100) <= 25 )
            {
                Instantiate(xp, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
//para a classe ser pai, ele tem que ser uma classe _abstract_
// se quiser que os inimigos virem o Flash, multiplique a velocidade deles
// nao e bom instanciar objetos num OnDestroy