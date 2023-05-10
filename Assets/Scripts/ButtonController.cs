using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button StartButton;

    private Button _currentButton;

    private void Start()
    {
        if (StartButton == null)
        {
            Debug.LogError("No start button selected for ButtonController");
        }

        _currentButton = StartButton;
        _currentButton.Select();
    }

    private void Update()
    {
        Vector2Int buttonDirection = InputManager.GetMenuNavigationDown();
        SelectNextButton(buttonDirection);
        if (InputManager.MenuSelectDown())
        {
            _currentButton.onClick?.Invoke();
        }
    }

    /// <summary>
    /// Changes current button and calls select on it using selectable navigation system.
    /// </summary>
    private void SelectNextButton(Vector2Int direction)
    {
        if (direction == Vector2Int.zero) return;

        if (direction == Vector2Int.up)
        {
            _currentButton = (Button)_currentButton.FindSelectableOnUp();
            _currentButton.Select();
            return;
        }

        if (direction == Vector2Int.down)
        {
            _currentButton = (Button)_currentButton.FindSelectableOnDown();
            _currentButton.Select();
            return;
        }

        if (direction == Vector2Int.left)
        {
            _currentButton = (Button)_currentButton.FindSelectableOnLeft();
            _currentButton.Select();
            return;
        }

        if (direction == Vector2Int.right)
        {
            _currentButton = (Button)_currentButton.FindSelectableOnRight();
            _currentButton.Select();
            return;
        }
    }
}
