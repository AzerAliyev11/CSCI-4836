using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class LabyrinthAI : MonoBehaviour
{
    public NavMeshSurface surface;

    [Header("NavMesh Agent")]
    public NavMeshAgent agent;

    public Transform endPoint;

    [Header("Endpoint Postitions")]
    public Transform[] endPointPositions;

    void Awake()
    {
        //Build the NavMesh when the game starts
        surface.BuildNavMesh();
    }

    void Start()
    {
        agent.SetDestination(endPoint.position);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeEndPoint();
        }
    }
    
    void ChangeEndPoint()
    {
        //Pick a random index from the endPointPositions array
        int randomIndex = Random.Range(0, endPointPositions.Length);

        //Set the endPoint's position to the position of the randomly selected endPointPosition
        endPoint.position = new Vector3(endPointPositions[randomIndex].position.x, endPoint.position.y, endPointPositions[randomIndex].position.z);
        agent.SetDestination(endPoint.position);
    }
}
