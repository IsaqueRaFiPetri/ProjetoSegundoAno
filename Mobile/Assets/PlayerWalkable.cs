using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalkable : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject arrowTarget;
    private void OnMouseDown()
    {
        Vector3 finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        finalPosition.z = 0;
        Destroy(Instantiate(arrowTarget, finalPosition, arrowTarget.transform.rotation), 2);        //coloque aqui o instanciador da setinha
        agent.SetDestination(finalPosition);
    }
}
