using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent mAgent;
    RaycastHit mHitInfo = new RaycastHit();
    
    void Start()
    {
        mAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out mHitInfo))
            {
                mAgent.destination = mHitInfo.point;
            }
        }
    }
}
