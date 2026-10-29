
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;

    public float detectionDistance = 20f;
    public float stopDistance = 1.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance;
    }

    void Update()
    {
        if (target == null || !agent.isOnNavMesh)
            return;

        float distance = Vector3.Distance(
            transform.position,
            target.position
        );

        if (distance <= detectionDistance)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.ResetPath();
        }
    }
}
