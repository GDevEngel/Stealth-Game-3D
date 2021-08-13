using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardTrigger : MonoBehaviour
{
    [SerializeField] GameObject _GrabKeyCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _GrabKeyCutscene.SetActive(true);
        }
    }
}
