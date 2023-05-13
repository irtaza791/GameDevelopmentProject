using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
   private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    private void update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }
}
