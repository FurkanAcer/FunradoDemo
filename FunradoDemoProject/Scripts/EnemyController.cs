using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform[] _waypoints;
    private int waypointIndex = 0;
    private NavMeshAgent _agent;
    Vector3 target;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            StartCoroutine(UpdateDestinationWithDelay());
            IterateWaypointIndex();
        }
    }
    IEnumerator UpdateDestinationWithDelay()
    {
        yield return new WaitForSeconds(1f);
        UpdateDestination();
    }

    void UpdateDestination()
    {
        target = _waypoints[waypointIndex].position;
        _agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == _waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}