using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private EventInstance _currentMusic;

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
            Debug.LogError("Found more than one Audio Manager in the scene.");
            Destroy(this);
        }
    }
    #endregion

    #region Initialization
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetMusicFromScene;
    }

    private void SetMusicFromScene(Scene scene, LoadSceneMode mode)
    {

        SetCurrentMusic(SceneData.Instance.SceneMusic);
    }
    #endregion

    #region General
    /// <summary>
    /// Plays sound once at position.
    /// </summary>
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    /// <summary>
    /// Plays sound once from a GameObjects position. Use this for moving objects.
    /// </summary>
    public void PlayOneShotAttached(EventReference sound, GameObject gameObject)
    {
        RuntimeManager.PlayOneShotAttached(sound, gameObject);
    }

    /// <summary>
    /// Creates a manipulateable instance. Use this for music and the like that is affected
    /// by parametres while being played. Remember to set3DAttributes if it is a 3D sound, in 
    /// addition to calling Release when done manipulating the instance.
    /// </summary>
    public EventInstance CreateEventInstance(EventReference sound)
    {
        return RuntimeManager.CreateInstance(sound); 
    }
    #endregion

    #region Music
    /// <summary>
    /// Sets the current music but DOES NOT STOP the previous music.
    /// </summary>
    public void SetCurrentMusic(EventReference newMusic)
    {
        _currentMusic.release();
        _currentMusic = CreateEventInstance(newMusic);
        _currentMusic.start();
    }

    public void PauseMusic()
    {
        _currentMusic.setPaused(true);
    }

    public void ResumeMusic()
    {
        _currentMusic.setPaused(false);
    }
    #endregion

    #region Muting
    public void MuteAll()
    {
        RuntimeManager.MuteAllEvents(true);
    }

    public void UnMuteAll()
    {
        RuntimeManager.MuteAllEvents(false);
    }
    #endregion
}
