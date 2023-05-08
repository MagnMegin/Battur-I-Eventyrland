using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputSettings", menuName = "InputManager/InputSettings", order = 1)]
public class InputSettings : ScriptableObject
{
    [Header("Overworld")]
    public string XMovementAxis;
    public string YMovementAxis;
    public KeyCode PrimaryInteraction;
    public KeyCode SecondaryInteraction;

    [Header("Combat")]
    public string CombatLeftRightAxis;
    public string CombatUpDownAxis;
    public KeyCode CombatSelect;
    public KeyCode CombatPrimaryInteraction;
    public KeyCode CombatSecondaryInteraction;

    [Header("Menu")]
    public string MenuLeftRightAxis;
    public string MenuUpDownAxis;
    public KeyCode MenuSelect;

    [Header("Intro sequence")]
    public KeyCode IntroSkip;
}
