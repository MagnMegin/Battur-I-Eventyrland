using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterInfo info;

    public void StartDialogue()
    {
        Dialogue.Instance.StartDialogue(info);
    }

    public void StartCombat()
    {

    }

}
