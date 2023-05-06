using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPoint : MonoBehaviour
{
    [Header("Interaction Area")]
    public float Radius = 0.5f;

    [Header("Interaction Keybinds")]
    public KeyCode PrimaryButton = KeyCode.E;
    public KeyCode SecondaryButton;

    [Header("Interaction Events")]
    public UnityEvent PrimaryInteraction;
    public UnityEvent SecondaryInteraction;

    private TestSnailController _character;

    #region Unity Messages
    void Start()
    {
        _character = FindObjectOfType<TestSnailController>();
        if (_character == null) Debug.LogWarning("Player character not found");
    }

    void Update()
    {
        if (!CharacterInRange()) return;

        if (Input.GetKeyDown(PrimaryButton))
        {
            PrimaryInteraction?.Invoke();
        }

        if (Input.GetKeyDown(SecondaryButton))
        {
            SecondaryInteraction?.Invoke();
        }
    }
    #endregion

    #region Helper Function
    /// <summary>
    /// Returns true if character is in range of interaction point.
    /// </summary>
    private bool CharacterInRange()
    {
        float distance = (_character.transform.position - transform.position).magnitude;
        return (distance < Radius);
    }
    #endregion

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, Vector3.forward, Radius, 1.5f);
    }
#endif
}
