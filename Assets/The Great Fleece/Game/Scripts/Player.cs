using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    //handle
    private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;


	// Use this for initialization
	void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();

        _animator.SetBool("Walk", false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("L-Clicked: ");

            _animator.SetBool("Walk", true);         

            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log("Ray: "+ray);
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log("Raycast hit something");
                //Debug.Log("hit world pos: "+ hit.point);
                //GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                //capsule.transform.position = hit.point;
                _agent.destination = hitInfo.point;
            }
        }
        /*
        Debug.Log("transform.position: " + transform.position);
        Debug.Log("agent destination: " + _agent.destination);
        if (transform.position.x == _agent.destination.x && transform.position.z == _agent.destination.z)
        {
            _animator.SetBool("Walk", false);
        }
        */

        float distance = Vector3.Distance(transform.position, _agent.destination);
        if (distance <= 1f)
        {
            _animator.SetBool("Walk", false);
        }

    }
}
