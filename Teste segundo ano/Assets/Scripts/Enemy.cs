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

    public void Moviment()
    {
        body.velocity = (PlayerMoviment.posPlayer.position - transform.position) * speed /10;
    }
}
//para a classe ser pai, ele tem que ser uma classe _abstract_
// se quiser que os inimigos virem o Flash, multiplique a velocidade deles