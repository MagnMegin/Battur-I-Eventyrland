using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // State
    public enum ControlScheme
    {
        Overworld,
        Combat,
        Menu,
        Video,
    }

    public static InputManager Instance;
    public static ControlScheme Scheme;

    public InputSettings Settings;

    #region Singleton Behaviour
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
        if (Scheme != ControlScheme.Overworld) return Vector3.zero;

        float x = Input.GetAxisRaw(Instance.Settings.XMovementAxis);
        float y = Input.GetAxisRaw(Instance.Settings.YMovementAxis);
        return (Vector3)(new Vector2(x, y).normalized);
    }

    public static bool PrimaryInteractionDown()
    {
        if (Scheme != ControlScheme.Overworld) return false;

        return Input.GetKeyDown(Instance.Settings.PrimaryInteraction);
    }

    public static bool SecondaryInteractionDown()
    {
        if (Scheme != ControlScheme.Overworld) return false;

        return Input.GetKeyDown(Instance.Settings.SecondaryInteraction);
    }
    #endregion

    #region Combat
    public static Vector2Int GetCombatNavigationDown()
    {
        //if (Scheme != ControlScheme.Combat) return Vector2Int.zero;

        int up = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuUpDownAxis));
        int right = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuLeftRightAxis));
        return new Vector2Int(up, right);
    }

    public static bool CombatPrimaryInteractionDown()
    {
        //if (Scheme != ControlScheme.Combat) return false;

        return Input.GetKeyDown(Instance.Settings.CombatPrimaryInteraction);
    }

    public static bool CombatSecondaryInteractionDown()
    {
        //if (Scheme != ControlScheme.Combat) return false;

        return Input.GetKeyDown(Instance.Settings.CombatSecondaryInteraction);
    }
    #endregion

    #region Menu
    public static Vector2Int GetMenuNavigationDown()
    {
        int up = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuUpDownAxis));
        int right = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuLeftRightAxis));
        return new Vector2Int(up, right);
    }

    public static bool MenuSelectDown()
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
