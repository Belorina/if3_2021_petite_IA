using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // prendez le reflex du requirecomponent! 
public class TobyManager : MonoBehaviour
{
    private NavMeshAgent agent;

    public List<TargetPoint> targetPoints = new List<TargetPoint>();
    private int indexNextDestination = 0;
    private Vector3 actualDestination;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(1, 100);
        agent.speed = Random.Range(1f, 10f);
        NextDestination();
    }

    // Update is called once per frame
    void Update()
    {

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();
        }
    }

    private void NextDestination()
    {
        int oldIndex = indexNextDestination;
        while (oldIndex == indexNextDestination && targetPoints.Count > 1)
        {
            indexNextDestination = Random.Range(0, targetPoints.Count);
            //print(indexNextDestination);

        }

        actualDestination = targetPoints[indexNextDestination].GivePoint();
        agent.SetDestination(actualDestination);

        // indexNextDestination++;
        // if (indexNextDestination >= targetPoints.Count) indexNextDestination = 0;
    }

    private void OnDrawGizmos()
    {
        if (agent != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(transform.position + Vector3.up * 2,
            0.5f + (100 - agent.avoidancePriority) * 0.01f);

        }
    }

}
