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
    string points;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        points = unit.currentPoints.ToString();
        pointsText.text = points;
        currentHealth.text = unit.currentHP + " / " + unit.maxHP;

    }

    public void UpdateHP(Unit unit, int damageTaken)
    {
        unit.currentHP = unit.currentHP - damageTaken;
    }

    public void UpdatePoints(Unit unit, int points)
    {
        unit.currentPoints = unit.currentPoints + points;
    }

}
