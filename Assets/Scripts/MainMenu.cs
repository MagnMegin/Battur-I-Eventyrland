using FMOD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayableDirector AnimationDirector;
    private bool _isStarting;

    public void StartGame()
    {
        _isStarting = true;
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(2);
        sceneLoad.allowSceneActivation = false;
        AnimationDirector.Play();
        while (AnimationDirector.state == PlayState.Playing)
        {
            yield return null;
        }
        sceneLoad.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        if (_isStarting) return;

        Application.Quit();
    }
}
