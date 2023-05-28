using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public EventInstance CurrentMusic => _currentMusic;
    public EventInstance CurrentAmbiance => _currentAmbiance;

    private EventInstance _currentMusic;
    private EventInstance _currentAmbiance;

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
            Debug.LogWarning("Found more than one Audio Manager in the scene.");
            Destroy(this);
        }
    }
    #endregion

    #region Initialization
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetMusicFromScene;
        SceneManager.sceneLoaded += SetAmbianceFromScene;
    }

    private void SetMusicFromScene(Scene scene, LoadSceneMode mode)
    {
        if (SceneData.Instance.SceneMusic.IsNull)
        {
            Debug.LogWarning("Scene has no music to play.");
        }
        else
        {
            SetCurrentMusic(SceneData.Instance.SceneMusic);
        }
    }
    private void SetAmbianceFromScene(Scene scene, LoadSceneMode mode)
    {
        if (SceneData.Instance.SceneAmbiance.IsNull)
        {
            Debug.LogWarning("Scene has no ambiance to play.");
        }
        else
        {
            SetCurrentAmbiance(SceneData.Instance.SceneAmbiance);
        }
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

    public void MuteAll()
    {
        RuntimeManager.MuteAllEvents(true);
    }

    public void UnMuteAll()
    {
        RuntimeManager.MuteAllEvents(false);
    }
    #endregion

    #region Music
    /// <summary>
    /// Sets the current music and realeases the previous music. NOTE: 
    /// DOES NOT STOP the previous music.
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
        Debug.Log("Music Paused");
    }

    public void ResumeMusic()
    {
        _currentMusic.setPaused(false);
        Debug.Log("Music Resumed");
    }
    #endregion

    #region Ambiance
    /// <summary>
    /// Sets the current ambiance and realeases the previous ambiance. NOTE: 
    /// DOES NOT STOP the previous ambiance.
    /// </summary>
    public void SetCurrentAmbiance(EventReference newAmbiance)
    {
        _currentAmbiance.release();
        _currentAmbiance = CreateEventInstance(newAmbiance);
        _currentAmbiance.start();
    }

    public void PauseAmbiance()
    {
        _currentAmbiance.setPaused(true);
        Debug.Log("Ambiance Paused");
    }

    public void ResumeAmbiance()
    {
        _currentAmbiance.setPaused(false);
        Debug.Log("Ambiance Resumed");
    }
    #endregion
}
