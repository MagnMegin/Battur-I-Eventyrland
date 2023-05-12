using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneData : MonoBehaviour
{
    // The base type of the scene
    public enum SceneType
    {
        Overworld,
        Menu,
        Cutscene,
        Bootstrap,
    }

    public static SceneData Instance;

    public SceneType TypeOfScene;
    public InputManager.ControlScheme BaseControlScheme;
    public AudioClip SceneMusic;

    public string SceneName { get; private set; }

    #region Unity Messages
    private void Awake()
    {
        if (Instance != null) Destroy(Instance.gameObject);
        Instance = this;

        SceneName = SceneManager.GetActiveScene().name;
    }
    #endregion
}
