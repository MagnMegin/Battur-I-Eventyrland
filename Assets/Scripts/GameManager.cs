using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    private static InputManager.ControlScheme _savedControlScheme;

    // Scene Data
    public SceneData.SceneType CurrentSceneType => SceneData.Instance.TypeOfScene;
    public InputManager.ControlScheme SceneBaseControlScheme 
                                                => SceneData.Instance.BaseControlScheme;

    // Intro Video
    public GameObject IntroVideo;

    #region Singleton
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
    #endregion

    #region Initialization

    // First-time initialization of GameManager
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetControlSchemeFromScene;
    }

    // First-time initialization of GameManager
    private void Start()
    {
        FindPlayerCharacter(); // Gets player character reference
        PlayIntroVideo();
    }
    #endregion

    #region Player Character
    /// <summary>
    /// For getting a reference to the player character. Notifies via event
    /// GameManager.OnNewCharacterInstance.
    /// </summary>
    private void FindPlayerCharacter()
    {
        PlayerCharacter = FindObjectOfType<AskeladdenController>()?.gameObject;
        OnNewCharacterInstance?.Invoke(PlayerCharacter);
    }
    #endregion

    #region Update
    private void Update()
    {
        // Search for player character in case it is not found in Start
        if (PlayerCharacter == null)
        {
            FindPlayerCharacter(); 
        }

        if (InputManager.PauseButtonDown())
        {
            if (GameIsPaused) ResumeGame();
            else PauseGame();
        }
    }
    #endregion

    #region Control Scheme
    /// <summary>
    /// Sets control scheme in input manager based on the current scene type.
    /// </summary>
    private void SetControlSchemeFromScene(Scene scene, LoadSceneMode loadMode)
    {
        InputManager.CurrentScheme = SceneBaseControlScheme;
    }

    private void SetControlSchemeFromScene()
    {
        InputManager.CurrentScheme = SceneBaseControlScheme;
    }
    #endregion

    #region Video
    public void PlayVideo(GameObject videoObject)
    {
        VideoController video = Instantiate(videoObject).GetComponent<VideoController>();
        InputManager.CurrentScheme = InputManager.ControlScheme.Cutscene;
        video.OnVideoEnd += SetControlSchemeFromScene;
    }

    private void PlayIntroVideo()
    {
        PlayVideo(IntroVideo);
    }
    #endregion

    #region Pause
    public void PauseGame()
    {
        // Only allow pause in overworld scenes
        if (CurrentSceneType != SceneData.SceneType.Overworld) return;

        // Save timescale and control scheme
        _savedTimeScale = Time.timeScale;
        _savedControlScheme = InputManager.CurrentScheme;

        Time.timeScale = 0f;
        InputManager.CurrentScheme = InputManager.ControlScheme.Menu;
        OnPause?.Invoke();
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        // Return to previous timescale and control scheme
        Time.timeScale = _savedTimeScale;
        InputManager.CurrentScheme = _savedControlScheme;

        OnResume?.Invoke();
        GameIsPaused = false;
    }
    #endregion
}
