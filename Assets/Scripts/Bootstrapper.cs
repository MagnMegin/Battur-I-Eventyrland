using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadBoatstrapScene()
    {
        SceneManager.LoadScene("Bootstrap", LoadSceneMode.Additive);
    }
}
