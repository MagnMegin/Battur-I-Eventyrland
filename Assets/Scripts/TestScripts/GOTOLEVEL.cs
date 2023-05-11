using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOTOLEVEL : MonoBehaviour
{
    public void Go()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
