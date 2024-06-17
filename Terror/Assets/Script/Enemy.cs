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
    public Transform vision, playerPos;
    RaycastHit hit;
    public Transform[] patrolPoints; //array - não muda dentro do jogo
    NavMeshAgent agent;
    MonsterAI monsterAI;
    bool isWaiting;
    
    int lastPoint; //Patrulha aleatória, impede repetir o ponto
    int patrolPoint; //Ponte de patrulha atual, para o de sequencia

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //SetDestiny();
        //SetRandomFixedPointDestiny();
        NextPointFixerdPatrol();
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
        //Linha de colisão para verificar se ta vendo o player
        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10) //se o player estiver longe, nem executa
                return;
            //print(hit.distance, ToString(playerPos"N0"));
            if (hit.collider.CompareTag("Player")) //caso veja o player
            {
                if (monsterAI.Equals(MonsterAI.Chasing)) //se bão for o modo CHASING
                {
                    monsterAI = MonsterAI.Chasing; //Mude para Chasing
                    isWaiting = false; //Cancela o Modo de Espera
                    StopAllCoroutines(); //Para a Coroutine do modo de espera
                }
                agent.SetDestination(playerPos.position);
                //Fica atualizañdo o destino dele para a posição do player
            }
            else
            { //se perder o player de vista
                if(monsterAI.Equals(MonsterAI.Chasing))
                    monsterAI = MonsterAI.Break; //caso ainda esteja caçando , cancela
            }
            
            print(hit.collider.name);
        }
    }
    IEnumerator GiveaBreak()
    {
        isWaiting = true; //Booleano que impede a dupla ativação
        yield return new WaitForSeconds(2); //tempo de espera
        NextPointFixerdPatrol(); //setar um novo destino e começar a patrulha
    }

    void SetDestiny() //anda para um ponto aleatório
    {
        agent.SetDestination(SetRandomNavTarget());
        monsterAI = MonsterAI.Patrolling;
    }
    void SetRandomFixedPointDestiny() //aleatopriza um dos pontos de patrulha
    {
        int random = Random.Range(0, patrolPoints.Length);
        while (random == lastPoint)
        {
            random = Random.Range(0, patrolPoints.Length);
        }
        lastPoint = random;
        print(random);
        agent.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].position);
        monsterAI = MonsterAI.Patrolling;
    }
    void NextPointFixerdPatrol()
    {
        agent.SetDestination(patrolPoints[patrolPoint].position);
        monsterAI = MonsterAI.Patrolling;
        patrolPoint++;
        if(patrolPoint >= patrolPoints.Length)
        {
            patrolPoint = 0;
        }
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