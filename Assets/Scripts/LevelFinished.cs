using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
