using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public Transform startCamera;

    private void Start()
    {
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;
    }


    void Update ()
    {
        transform.LookAt(_player.transform);
	}
}
