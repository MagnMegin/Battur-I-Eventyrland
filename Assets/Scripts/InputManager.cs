using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Control scheme (state of input manager)
    public enum ControlScheme
    {
        Overworld,
        Combat,
        Menu,
        Cutscene,
        None,
    }

    public static InputManager Instance;
    public static ControlScheme CurrentScheme;

    public InputSettings Settings;

    private static bool _combatNavigationRegistered;
    private static bool _menuNavigationRegistered;

    #region Unity Messages

    // Awake is used for singleton behaviour
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
    // Update is used for keeping track of input (specifically menu and combat navigation)
    private void Update()
    {
        // Resets GetCombatNavigationDown method once GetCombatNavigation returns [0,0]
        if (_combatNavigationRegistered && GetCombatNavigation() == Vector2Int.zero)
        {
            _combatNavigationRegistered = false;
        }

        // Same thing but for GetMenuNavigationDown
        if (_menuNavigationRegistered && GetMenuNavigation() == Vector2Int.zero)
        {
            _menuNavigationRegistered = false;
        }
    }
    #endregion

    #region General
    public static bool PauseButtonDown()
    {
        return Input.GetKeyDown(Instance.Settings.PauseButton);
    }
    #endregion

    #region Overworld
    public static Vector3 GetMovement()
    {
        if (CurrentScheme != ControlScheme.Overworld) return Vector3.zero;

        float x = Input.GetAxisRaw(Instance.Settings.XMovementAxis);
        float y = Input.GetAxisRaw(Instance.Settings.YMovementAxis);
        return (Vector3)(new Vector2(x, y).normalized);
    }

    public static bool PrimaryInteractionDown()
    {
        if (CurrentScheme != ControlScheme.Overworld) return false;

        return Input.GetKeyDown(Instance.Settings.PrimaryInteraction);
    }

    public static bool SecondaryInteractionDown()
    {
        if (CurrentScheme != ControlScheme.Overworld) return false;

        return Input.GetKeyDown(Instance.Settings.SecondaryInteraction);
    }
    #endregion

    #region Combat
    public static Vector2Int GetCombatNavigation()
    {
        if (CurrentScheme != ControlScheme.Combat) return Vector2Int.zero;

        int up = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuUpDownAxis));
        int right = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuLeftRightAxis));

        return new Vector2Int(up, right);
    }

    public static Vector2Int GetCombatNavigationDown()
    {
        if (CurrentScheme != ControlScheme.Combat) return Vector2Int.zero;
        if (_combatNavigationRegistered) return Vector2Int.zero; // To prevent input on more than one frame

        _combatNavigationRegistered = true;

        return GetCombatNavigation();
    }

    public static bool CombatPrimaryInteractionDown()
    {
        if (CurrentScheme != ControlScheme.Combat) return false;

        return Input.GetKeyDown(Instance.Settings.CombatPrimaryInteraction);
    }

    public static bool CombatSecondaryInteractionDown()
    {
        if (CurrentScheme != ControlScheme.Combat) return false;

        return Input.GetKeyDown(Instance.Settings.CombatSecondaryInteraction);
    }
    #endregion

    #region Menu
    public static Vector2Int GetMenuNavigation()
    {
        if (CurrentScheme != ControlScheme.Menu) return Vector2Int.zero;

        int up = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuUpDownAxis));
        int right = Mathf.RoundToInt(Input.GetAxisRaw(Instance.Settings.MenuLeftRightAxis));

        return new Vector2Int(up, right);
    }

    public static Vector2Int GetMenuNavigationDown()
    {
        if (CurrentScheme != ControlScheme.Menu) return Vector2Int.zero;
        if (_menuNavigationRegistered) return Vector2Int.zero; // To prevent input on more than one frame

        _menuNavigationRegistered = true;

        return GetCombatNavigation();
    }

    public static bool MenuSelectDown()
    {
        if (CurrentScheme != ControlScheme.Menu) return false;

        return Input.GetKeyDown(Instance.Settings.MenuSelect);
    }
    #endregion

    #region Video
    public static bool GetIntroSkipDown()
    {
        if (CurrentScheme != ControlScheme.Cutscene) return false;

        return Input.GetKeyDown(Instance.Settings.IntroSkip);
    }
    #endregion
}
