
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;
    public GameObject Audio;
    public GameObject gameOverImage;

    public float detectionDistance = 20f;
    public float stopDistance = 1.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.stoppingDistance = stopDistance;

        gameOverImage.SetActive(false);
    }

    void Update()
    {
        if (target == null || !agent.isOnNavMesh)
            return;

        float distance = Vector3.Distance(
            transform.position, target.position
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected!");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched enemy!");

            Audio.SetActive(false);
            gameOverImage.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

