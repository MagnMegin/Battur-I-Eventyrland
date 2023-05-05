using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public KeyCode SkipVideoKey;

    private VideoPlayer _vidPlayer;

    void Start()
    {
        _vidPlayer = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(SkipVideoKey))
        {
            Destroy(gameObject);
        }
    }
}
