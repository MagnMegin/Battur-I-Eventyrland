using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectBubble : MonoBehaviour
{
    public Image charPortrait;
    public TextMeshProUGUI inspectText;

    private void Start()
    {
        StartCoroutine(DestroyBubble());
    }

    public void Initialize(ItemInfo info)
    {
        inspectText.text = info.itemDescription;
        charPortrait.sprite = info.characterPortrait;
    }

    private IEnumerator DestroyBubble()
    {
        yield return new WaitForSeconds(8);
        Destroy(gameObject);
    }
}
