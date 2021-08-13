using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    //handle 
    public AudioClip _audioClip;

    private bool _isPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && _isPlayed == false)
        {
            AudioManager.Instance.PlayVoiceOver(_audioClip);
            _isPlayed = true;
        }
    }
}
