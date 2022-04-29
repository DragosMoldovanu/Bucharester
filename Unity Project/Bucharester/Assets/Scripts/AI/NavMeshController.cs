using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        //agent is going where the player clicks
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                agent.SetDestination(hit.point);
        }

        //testing with a preset position
        if (Input.GetKeyDown(KeyCode.L))
            agent.SetDestination(new Vector3(10, 0, 20));
    }
}
