using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHelper : MonoBehaviour
{
    Character _thisCharacter;

    public void StartInteract()
    {
        Dialogue.Instance.onDialogueOver += OnDialogueFinished;
        _thisCharacter = GetComponent<Character>();
    }
    private void OnDisable()
    {
        Dialogue.Instance.onDialogueOver -= OnDialogueFinished;
    }
    void OnDialogueFinished()
    {
        if (Dialogue.Instance.lines == _thisCharacter.info.lines)
        {
            this.gameObject.SetActive(false);
        }
    }

}
