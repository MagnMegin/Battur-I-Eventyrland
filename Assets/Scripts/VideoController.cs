using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public bool PlayInEditor;

    public bool VideoIsFinished => (_vidPlayer.frame == (long)_totalFrames - 1);

    public event Action OnVideoEnd;

    private VideoPlayer _vidPlayer;
    private ulong _totalFrames;

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
        _totalFrames = _vidPlayer.frameCount;
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
        Destroy(gameObject);
        OnVideoEnd?.Invoke();
    }
}
