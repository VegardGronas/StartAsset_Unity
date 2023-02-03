using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public MainSettings MainSettings { get; set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //Only call this in the beginning of the game
    public void InitializeGameobjects(GameState state, MainSettings settings = null)
    {
        if (settings) MainSettings = settings;
        else if (!MainSettings) { Debug.LogError("No gamesettings added"); return; }
        switch (state)
        {
            case GameState.Menu:
                if (MainSettings.soundManager) Instantiate(MainSettings.soundManager);
                if (MainSettings.mainMenuUI) Instantiate(MainSettings.mainMenuUI);
                break;
            case GameState.Game:
                if (MainSettings.soundManager) Instantiate(MainSettings.soundManager);
                if (MainSettings.playerPrefab) Instantiate(MainSettings.playerPrefab);
                break;
            case GameState.Development:
                //Some dev stuff maybe idk

                break;
        }
    }
    //_______________________________

    public void LoadAsyncScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}