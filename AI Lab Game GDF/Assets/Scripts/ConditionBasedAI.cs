using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ConditionBasedAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public float moveDistance = 7f;

    void OnDrawGizmos()
    {
        //Drawing a sphere around the AI to visualize the distance at which it will start moving towards the player
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, moveDistance);
    }

    void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude < moveDistance)
        {
            agent.SetDestination(player.position);
            Debug.Log("Player is within range. AI is moving towards the player.");
        }
        else
        {
            Debug.Log("Player is too far away. AI is idle.");
        }
    }


}
