using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    private EventInstance _currentMusic;

    private void Start()
    {
        _currentMusic = AudioManager.Instance.CurrentMusic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentMusic.setParameterByName("DYSTER SKOG", 3f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _currentMusic.setParameterByName("DYSTER SKOG", 0f);

    }
}
