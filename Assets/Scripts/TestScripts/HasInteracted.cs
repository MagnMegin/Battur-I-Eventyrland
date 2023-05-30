using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasInteracted : MonoBehaviour
{
    Character _thisCharacter;
    public TestMechTriggerManager MechManager;

    public void StartInteract()
    {
        StartCoroutine(InteractSetup());
    }

    private IEnumerator InteractSetup()
    {
        yield return null;
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
            MechManager._talkedToRabbit = true;
        }
    }

}
