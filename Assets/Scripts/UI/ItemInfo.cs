using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item Information", order = 2)]
public class ItemInfo : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite characterPortrait; //Portait of Askeladden. Used to change feelings (thinking, smiling, angry) when inspecting the item.
    public GameObject InspectBubble;
}
