using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseScript : MonoBehaviour
{
    public GameObject Player1;
    void DoSomething()
    {
        ButtonAcessPanel.Player1 = Instantiate(Player1);
    }
}
