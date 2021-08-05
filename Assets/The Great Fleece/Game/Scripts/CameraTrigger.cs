using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    /// <summary>
    /// check for trigger of player
    /// update main camera to appropriate angle
    /// </summary>
    /// <param name="other"></param>

    //handle
    [SerializeField] private GameObject _targetCamera;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggered activated");           
            Camera.main.transform.position = _targetCamera.transform.position;
            Camera.main.transform.rotation = _targetCamera.transform.rotation; 
        }
    }
}
