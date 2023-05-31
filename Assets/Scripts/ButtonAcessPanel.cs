using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAcessPanel : MonoBehaviour
{
    public static GameObject Obj1;
    public static GameObject Obj2;
    public static GameObject Obj3;

    public void CallMethodOnObject1(string MethodName)
    {
        Obj1.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
    }

    public void CallMethodOnObject2(string MethodName)
    {
        Obj2.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
    }

    public void CallMethodOnObject3(string MethodName)
    {
        Obj3.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
    }
}
