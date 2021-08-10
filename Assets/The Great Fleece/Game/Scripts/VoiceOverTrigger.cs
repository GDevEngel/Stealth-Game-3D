using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    //handle 
    private AudioSource _audioSource;

    private bool _isPlayed = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isPlayed == false)
        {
            _audioSource.Play();
            _isPlayed = true;
        }

    }
}
