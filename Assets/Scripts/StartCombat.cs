using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombat : MonoBehaviour
{
    public GameObject Combat;

    public void InitiateCombat()
    {
        StartCoroutine(Initiate());
    }

    public IEnumerator Initiate()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(Combat);
    }
}
