using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public static GameStateHandler Instance { get; private set; }

    [SerializeField] private GameState currentState;
    [SerializeField] private MainSettings _mainSettings;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GameManager.Instance.InitializeGameobjects(currentState, _mainSettings);
    }
}
