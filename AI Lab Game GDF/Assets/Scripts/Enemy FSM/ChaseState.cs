using UnityEngine;
using UnityEngine.AI;


public class ChaseState : State
{
    public NavMeshAgent agent;
    public Transform player;

    public AttackState attackState;
    public bool isInAttackRange;

    public override State RunCurrentState()
    {
        agent.SetDestination(player.position);
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
