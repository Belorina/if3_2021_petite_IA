using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]        // prendez le reflex du requirecomponent! 
public class TobyManager : MonoBehaviour
{
    private NavMeshAgent agent;

    public List<TargetPoint> targetPoints = new List<TargetPoint>();

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
