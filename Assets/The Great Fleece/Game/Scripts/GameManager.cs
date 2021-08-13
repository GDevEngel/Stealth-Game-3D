using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Gamemanager is NULL");
            }
            return _instance;
        }
    }

    public bool HasCard { get; set; }
    public PlayableDirector introCutscene;

    private bool _isBGMON = false;

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && _isBGMON == false)
        {
            introCutscene.time = 61f;
            AudioManager.Instance.PlayBGM();
            _isBGMON = true;
        }
    }
}
