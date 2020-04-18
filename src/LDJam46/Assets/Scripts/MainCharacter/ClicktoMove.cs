using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClicktoMove : MonoBehaviour
{    
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateUpAxis = false;
        _agent.updateRotation = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) {            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, whatCanBeClickedOn)) {
                _agent.SetDestination(hitInfo.point);                
            }
        }
    }
}
