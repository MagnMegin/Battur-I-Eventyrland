using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

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

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateEventInstance(EventReference sound)
    {
        return RuntimeManager.CreateInstance(sound); 
    }

    public void PauseMusic()
    {

    }

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
