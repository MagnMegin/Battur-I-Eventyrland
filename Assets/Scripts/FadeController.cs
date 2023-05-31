using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image img;

    private bool _fadeIn;

    public void DoFade(GameObject video)
    {
        StartCoroutine(FadeOut(video));
    }

    private IEnumerator FadeOut(GameObject video)
    {
        img.CrossFadeAlpha(0f, 0f, ignoreTimeScale: false);
        img.CrossFadeAlpha(1f, 1f, ignoreTimeScale: false);
        yield return new WaitForSeconds(1f);
        Destroy(video);
        img.CrossFadeAlpha(0f, 1f, ignoreTimeScale: false);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
