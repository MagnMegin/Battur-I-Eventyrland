using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action OnPause;
    public static event Action OnResume;

    public static bool GameIsPaused { get; private set; } = false;

    private static float _savedTimeScale;

    #region Singleton
    void Awake()
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
