using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Main Menu")]
    [field: SerializeField] public EventReference MenuAtmos { get; private set; }
    [field: SerializeField] public EventReference MenuMusic { get; private set; }

    public static FMODEvents Instance;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion
}
