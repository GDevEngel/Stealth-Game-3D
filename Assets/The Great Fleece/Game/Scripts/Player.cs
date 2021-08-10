using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    //handle
    private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _coinPrefab;

    //config
    private bool _coinThrown = false;

	// Use this for initialization
	void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();

        _animator.SetBool("Walk", false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // if left click
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("Walk", true);         

            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                _agent.destination = hitInfo.point;
            }
        }

        // if right click
        if (Input.GetMouseButtonDown(1) && _coinThrown == false)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                _animator.SetTrigger("CoinThrow");
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                _coinThrown = true;
                SendAIToCoinSpot(hitInfo.point);
            }
        }

        float distance = Vector3.Distance(transform.position, _agent.destination);
        if (distance <= 1f)
        {
            _animator.SetBool("Walk", false);
        }
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] Guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (GameObject guard in Guards)
        {
            guard.GetComponent<GuardAI>().CheckForCoin(coinPos);
        }
    }
}