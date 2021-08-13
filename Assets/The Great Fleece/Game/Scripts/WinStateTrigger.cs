using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateTrigger : MonoBehaviour
{
    [SerializeField] GameObject _winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("trigger player found");
            if (GameManager.Instance.HasCard == true)
            {
                Debug.Log("card is true n trying to activate win cutscene");
                _winCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("get the key card to open the vault");
            }
        }

    }
}
