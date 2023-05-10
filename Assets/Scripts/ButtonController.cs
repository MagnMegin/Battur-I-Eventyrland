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
            SelectUpButton();
            return;
        }

        if (direction == Vector2Int.down)
        {
            SelectDownButton();
            return;
        }

        if (direction == Vector2Int.left)
        {
            SelectLeftButton();
            return;
        }

        if (direction == Vector2Int.right)
        {
            SelectRightButton();
            return;
        }
    }

    private void SelectUpButton()
    {
        Button nextButton = (Button)_currentButton.FindSelectableOnUp();
        if (nextButton != null)
        {
            _currentButton = nextButton;
            _currentButton.Select();
        }
        return;
    }

    private void SelectDownButton()
    {
        Button nextButton = (Button)_currentButton.FindSelectableOnDown();
        if (nextButton != null)
        {
            _currentButton = nextButton;
            _currentButton.Select();
        }
        return;
    }
    private void SelectLeftButton()
    {
        Button nextButton = (Button)_currentButton.FindSelectableOnLeft();
        if (nextButton != null)
        {
            _currentButton = nextButton;
            _currentButton.Select();
        }
        return;
    }

    private void SelectRightButton()
    {
        Button nextButton = (Button)_currentButton.FindSelectableOnRight();
        if (nextButton != null)
        {
            _currentButton = nextButton;
            _currentButton.Select();
        }
        return;
    }
}
