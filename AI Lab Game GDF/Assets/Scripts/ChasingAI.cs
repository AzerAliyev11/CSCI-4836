using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class ChasingAI : MonoBehaviour
{
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    public Transform player;

    void Awake()
    {
        surface.BuildNavMesh();
    }

    void Update()
    {
        //Every frame, set the destination of the agent to the player's position
        agent.SetDestination(player.position);
    }
}
