using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public event Action OnMapClose;

    public void ToKristiania()
    {
        CloseMap();
    }

    public void ToRoros()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void CloseMap()
    {
        OnMapClose?.Invoke();
        Destroy(gameObject);
    }
}
