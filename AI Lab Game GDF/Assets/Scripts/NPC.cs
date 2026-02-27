using System;
using UnityEngine;
using UnityEngine.AI;

enum NPC_State {
    Patrol,
    Chase
};

public class NPC : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;

    private Transform currentDestination;
    private int index;
    private NPC_State npc_state;
    private Transform playerTransform;

    void Start()
    {
        npc_state = NPC_State.Patrol;
        index = 0;
        currentDestination = waypoints[0];
        agent.SetDestination(currentDestination.position);
    }

    void Update()
    {
        switch(npc_state)
        {
            case NPC_State.Patrol:
                PatrollingLogic();
                break;
            case NPC_State.Chase:
                ChaseLogic();
                break;
            default:
                break;
        }
    }

    private void PatrollingLogic()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            index++;
            if(index >= waypoints.Length)
            {
                index = 0;
            }
            currentDestination = waypoints[index];
            agent.SetDestination(currentDestination.position);
        }
    }

    private void ChaseLogic()
    {
        agent.SetDestination(playerTransform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            npc_state = NPC_State.Chase;
            playerTransform = other.gameObject.transform;
        }
    }
}
