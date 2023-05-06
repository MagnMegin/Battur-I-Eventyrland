using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public InputSettings Settings;

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

    #region Overworld
    public static Vector3 GetMovement()
    {
        float x = Input.GetAxisRaw(Instance.Settings.X_Movement);
        float y = Input.GetAxisRaw(Instance.Settings.Y_Movement);
        return (Vector3)(new Vector2(x, y).normalized);
    }

    public static bool GetPrimaryInteractionDown()
    {
        return Input.GetKeyDown(Instance.Settings.PrimaryInteraction);
    }

    public static bool GetSecondaryInteractionDown()
    {
        return Input.GetKeyDown(Instance.Settings.SecondaryInteraction);
    }
    #endregion

    #region Combat
    public static bool GetPrimaryCombatInteractionDown()
    {
        return false;
    }

    public static bool GetSecondaryCombatInteractionDown()
    {
        return false;
    }
    #endregion

    #region Menu
    public static Vector2Int GetMenuNavigation()
    {
        int up = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuUpDown));
        int right = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuLeftRight));
        return new Vector2Int(up, right);
    }

    public static bool GetMenuSelectDown()
    {
        return Input.GetKeyDown(Instance.Settings.MenuSelect);
    }
    #endregion

    #region Intro Sequence
    public static bool GetIntroSkipDown()
    {
        return Input.GetKeyDown(Instance.Settings.IntroSkip);
    }
    #endregion
}
