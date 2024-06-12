using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterAI
{
    Break, Patrolling, Chasing
}
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public Transform[] patrolPoints; //array - não muda dentro do jogo
    NavMeshAgent agent;
    MonsterAI monsterAI;
    bool isWaiting;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestiny();
    }
    void Update()
    {
        //agent.SetDestination(PlayerInteraction.instance.transform.position);
        switch (monsterAI)
        {
            case MonsterAI.Break: //modod de aguardo
                if (isWaiting) //se estiver true nem lê o rsto
                    return; //para previnir de ativar duas vezes abaixo

                StartCoroutine(GiveaBreak()); //coroutine para esperar
                break;
            case MonsterAI.Patrolling:
                isWaiting = false; //desativando a booleana para depois
                if(agent.stoppingDistance >= agent.remainingDistance) 
                { //se estiver chegando ao destino, espere
                    monsterAI = MonsterAI.Break;
                }
                break;
            case MonsterAI.Chasing:
                break;
        }
    }
    IEnumerator GiveaBreak()
    {
        isWaiting = true; //Booleano que impede a dupla ativação
        yield return new WaitForSeconds(2); //tempo de espera
        SetDestiny(); //setar um novo destino e começar a patrulha
    }

    void SetDestiny()
    {
        agent.SetDestination(SetRandomNavTarget());
        monsterAI = MonsterAI.Patrolling;
    }
    void SetRandomFixedPointDestiny()
    {
        agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
        monsterAI = MonsterAI.Patrolling;
    }

    Vector3 SetRandomNavTarget()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 30;
        randomPosition.y = 0;
        randomPosition += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, 5, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }
}