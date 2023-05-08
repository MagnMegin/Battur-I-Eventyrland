using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Video,
        Pause
    }

    // Instance
    public static GameManager Instance;

    // Events
    public static event Action<GameObject> OnNewCharacterInstance;
    public static event Action OnPause;
    public static event Action OnResume;

    // Player Character
    public static GameObject PlayerCharacter;

    // Pausing
    public static bool GameIsPaused { get; private set; } = false;
    private static float _savedTimeScale;

    // Scene Data
    private static SceneData CurrentSceneData;

    #region Unity Messages
    // Singleton behaviour and start up
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    // First-time initialization of GameManager
    private void Start()
    {
        FindPlayerCharacter(); // Gets player character reference
        InputManager.Scheme = InputManager.ControlScheme.Video; // Sets control scheme
    }

    // Search for player character in case it is not found in Awake
    private void Update()
    {
        if (PlayerCharacter == null)
        {
            FindPlayerCharacter();
        }
    }
    #endregion

    #region Initialization and Reloading

    /// <summary>
    /// For getting a reference to the player character. Notifies via event
    /// GameManager.OnNewCharacterInstance.
    /// </summary>
    private void FindPlayerCharacter()
    {
        PlayerCharacter = FindObjectOfType<AskeladdenController>()?.gameObject;
        OnNewCharacterInstance?.Invoke(PlayerCharacter); // Message to scripts in case of character reload
    }

    private void Initialize()
    {
        FindPlayerCharacter(); // Gets player character reference
        CurrentSceneData = SceneData.Instance;
        InputManager.Scheme = InputManager.ControlScheme.Video; // Sets control scheme

    }
    #endregion

    #region Pause
    public void PauseGame()
    {
        _savedTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        OnPause?.Invoke();
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = _savedTimeScale;
        OnResume?.Invoke();
        GameIsPaused = false;
    }
    #endregion
}
