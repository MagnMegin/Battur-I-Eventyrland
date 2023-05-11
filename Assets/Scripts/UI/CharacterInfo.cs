using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character Information", order = 1)]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public string characterDescription;
    public Sprite characterDialogueSprite;
    public string[] lines;
}
