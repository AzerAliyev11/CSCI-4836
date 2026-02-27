using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;

    public IdleState idleState;
    public ChaseState chaseState;
    public AttackState attackState;

    [Header("State Transition Ranges")]
    public float chaseRadius = 5f;
    public float attackRange = 3f;
    
    public Transform player;

    void Update()
    {
        Debug.Log("Current State: " + currentState.GetType().Name);
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= chaseRadius)
        {
            if (distanceToPlayer.magnitude <= attackRange)
            {
                currentState = attackState;
            }
            else
            {
                currentState = chaseState;
            }
        }
        else
        {
            currentState = idleState;
        }

        RunStateMachine();
    }

    void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            //Switch to the next state
            SwitchToNextState(nextState);
        }
    }

    void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
