using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverCutscene;
    [SerializeField] private Animator _animator;
    private MeshRenderer _meshRenderer;
    private Color newColor = new Color(1f, 0.4f, 0.4f, 0.04f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            if (_meshRenderer != null)
            {
                _meshRenderer.material.SetColor("_TintColor", newColor);
            }
            else
            {
                Debug.Log("meshrenderer is null");
            }
            _animator.enabled = false;
            StartCoroutine(StartGameOverCutscene());
        }
    }

    IEnumerator StartGameOverCutscene()
    {
        yield return new WaitForSeconds(0.5f);
        _gameoverCutscene.SetActive(true);
    }
}