using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputSettings", menuName = "InputManager/InputSettings", order = 1)]
public class InputSettings : ScriptableObject
{
    [Header("Movement")]
    public string X_Movement;
    public string Y_Movement;

    [Header("Interactions")]
    public KeyCode PrimaryInteraction;
    public KeyCode SecondaryInteraction;

    [Header("Menu")]
    public string MenuUpDown;
    public string MenuLeftRight;
    public KeyCode MenuSelect;

    [Header("Intro sequence")]
    public KeyCode IntroSkip;
}
