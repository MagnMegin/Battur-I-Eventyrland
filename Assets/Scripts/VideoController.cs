using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public GameObject VideoFade;
    public bool PlayInEditor;

    public bool VideoIsFinished => (_vidPlayer.frame == 1160);

    public event Action OnVideoEnd;

    private VideoPlayer _vidPlayer;
    private long _totalFrames;
    private bool _isEnding;

    private void Start()
    {
        #if UNITY_EDITOR
        if (!PlayInEditor)
        {
            EndVideo();
            return;
        }
        #endif

        _vidPlayer = GetComponent<VideoPlayer>();
        _totalFrames = (long)_vidPlayer.frameCount;
    }
    private void Update()
    {
        if (InputManager.GetIntroSkipDown())
        {
            EndVideo();
        }

        if (VideoIsFinished)
        {
            EndVideo();
        }
    }

    public void EndVideo()
    {
        if (_isEnding) return;
        _isEnding = true;

        FadeController fade = Instantiate(VideoFade).GetComponent<FadeController>();
        fade.DoFade(this.gameObject);
        OnVideoEnd?.Invoke();
    }
}
