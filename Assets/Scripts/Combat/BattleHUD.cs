using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI currentHealth;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        pointsText.text = unit.currentPoints + " ability points";
        currentHealth.text = unit.currentHP + " / " + unit.maxHP + " helse";

    }

    public void UpdateHP(Unit unit, int damageTaken)
    {
        unit.currentHP = unit.currentHP - damageTaken;
    }


}
