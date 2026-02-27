using UnityEngine;
using UnityEngine.AI;

enum AI_STATE
{
    PATROL,
    CHASE
};

public class NPC_Brain : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] destinationTransforms;
    
    private Vector3 currentDestination;
    private int index;
    private Transform playerTransform;
    private AI_STATE ai_state;

    void Start()
    {
        ai_state = AI_STATE.PATROL;
        index = 0;
        currentDestination = destinationTransforms[index].position;
        agent.SetDestination(currentDestination);
    }

    void Update()
    {
        switch(ai_state)
        {
            case AI_STATE.PATROL:
                PatrolLogic();
                break;
            case AI_STATE.CHASE:
                ChaseLogic();
                break;
            default:
                break;
        }
    }

    private void ChaseLogic()
    {
        agent.SetDestination(playerTransform.position);
    }

    private void PatrolLogic()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            index++;
            if(index >= destinationTransforms.Length)
            {
                index = 0;
            }
            currentDestination = destinationTransforms[index].position;
            agent.SetDestination(currentDestination);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerTransform = other.gameObject.transform;
            ai_state = AI_STATE.CHASE;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ai_state = AI_STATE.PATROL;
        }
    }
}
