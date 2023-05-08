using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public bool PlayInEditor;

    public event Action OnVideoEnd;

    private void Start()
    {
        #if UNITY_EDITOR
        if (!PlayInEditor)
        {
            Destroy(gameObject);
            return;
        }
        #endif
    }
    private void Update()
    {
        if (InputManager.GetIntroSkipDown())
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}
