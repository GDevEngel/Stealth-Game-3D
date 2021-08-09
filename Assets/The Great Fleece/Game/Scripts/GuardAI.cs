using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    //handle
    private NavMeshAgent _agent;
    public List<Transform> waypoints;
    private Animator _animator;

    //var
    private int currentTarget = 0;
    private bool _isReverse = false;
    private bool _targetReached;

    //config
    private float _waitToMoveMin = 2f;
    private float _waitToMoveMax = 5f;

    // Use this for initialization
    void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (waypoints.Count > 0 && waypoints[currentTarget] != null)
        {           

            float distance = Vector3.Distance(transform.position, waypoints[currentTarget].position);
            if (distance < 1 && _targetReached == false)
            {
                _targetReached = true;

                if (currentTarget >= waypoints.Count - 1)
                {
                    _isReverse = true;
                    StartCoroutine(WaitBeforeMoving());
                }
                else if (currentTarget <= 0)
                {
                    _isReverse = false;
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    ChangeWaypoint();
                }
            }
            _agent.SetDestination(waypoints[currentTarget].position);
        }
    }

    void ChangeWaypoint()
    {
        _targetReached = false;

        if (_isReverse == true)
        {
            currentTarget--;
        }
        else if (_isReverse == false)
        {
            currentTarget++;
        }
        _animator.SetBool("Walk", true);
    }

    IEnumerator WaitBeforeMoving()
    {
        _animator.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(_waitToMoveMin, _waitToMoveMax));
        ChangeWaypoint();
    }
}