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
    private bool _targetReached = false;
    private bool _coinSearching = false;

    //config
    private float _waitToMoveMin = 2f;
    private float _waitToMoveMax = 5f;

    // Use this for initialization
    void Start ()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _animator.SetBool("Walk", true);
        _agent.SetDestination(waypoints[currentTarget].position);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (waypoints.Count > 0 && waypoints[currentTarget] != null)
        {           

            float distance = Vector3.Distance(transform.position, _agent.destination);
            if (distance < 2.5f && _targetReached == false)
            {
                _targetReached = true;

                if (_coinSearching == true)
                {
                    StartCoroutine(SearchForCoin());
                }
                else if (currentTarget >= waypoints.Count - 1)
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
            
        }
    }

    void ChangeWaypoint()
    {
        if (_coinSearching == false)
        {
            _targetReached = false;

            if (waypoints.Count != 1)
            {
                if (_isReverse == true)
                {
                    currentTarget--;
                }
                else if (_isReverse == false)
                {
                    currentTarget++;
                }
                _agent.SetDestination(waypoints[currentTarget].position);
                _animator.SetBool("Walk", true);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        _animator.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(_waitToMoveMin, _waitToMoveMax));
        ChangeWaypoint();
    }

    public void CheckForCoin(Vector3 CoinPos)
    {
        _agent.SetDestination(CoinPos);
        _animator.SetBool("Walk", true);
        _coinSearching = true;
        _targetReached = false;
    }

    IEnumerator SearchForCoin()
    {
        _animator.SetBool("Walk", false);
        yield return new WaitForSeconds(Random.Range(_waitToMoveMin, _waitToMoveMax));

        _animator.SetBool("Walk", true);

        _coinSearching = false;

        _targetReached = false;
        if (waypoints[currentTarget] != null)
        {
            _agent.SetDestination(waypoints[currentTarget].position);
        }
        else
        {
            _agent.SetDestination(waypoints[0].position);
        }
    }
}