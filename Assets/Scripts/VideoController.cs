using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    void Update()
    {
        if (InputManager.GetIntroSkipDown())
        {
            Destroy(gameObject);
        }
    }
}
