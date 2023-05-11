using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSystem : MonoBehaviour
{
    public AudioSource Audio;

    public static MusicSystem Instance;

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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += PlaySceneMusic;
    }
    #endregion

    private void PlaySceneMusic(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(Audio);
        Audio.clip = SceneData.Instance.SceneMusic;

        if (Audio.clip != null) Audio.Play();
        else Debug.LogWarning("No music to play.");
    }
}
