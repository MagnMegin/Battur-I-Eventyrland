using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static PauseScreen Instance;

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
    private void Start()
    {
        GameManager.OnPause += Enable;
        GameManager.OnResume += Disable;
        Disable();
    }
    #endregion

    #region Enable and Disable
    private void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
    #endregion

    #region Button Functions
    public void ToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        GameManager.Instance.ResumeGame();
    }

    public void Resume()
    {
        GameManager.Instance.ResumeGame();
    }
    #endregion
}
