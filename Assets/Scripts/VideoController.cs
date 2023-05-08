using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public bool PlayInEditor;
    private void Start()
    {
        #if UNITY_EDITOR
        if (!PlayInEditor)
        {
            Destroy(gameObject);
        }
        #endif
    }
    void Update()
    {
        if (InputManager.GetIntroSkipDown())
        {
            Destroy(gameObject);
        }
    }
}
