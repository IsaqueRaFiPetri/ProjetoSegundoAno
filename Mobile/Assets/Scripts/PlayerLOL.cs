using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLOL : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            print("CHEGUEI"); 
        }
    }
}
