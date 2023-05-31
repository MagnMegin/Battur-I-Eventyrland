using UnityEngine;

public class ButtonAcessPanel : MonoBehaviour
{
    public static GameObject Player1;
    public static GameObject Player2;

    public void CallMethodOnPlayer1(string MethodName)
    {
        Player1.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
    }

    public void CallMethodOnplayer2(string MethodName)
    {
        Player2.SendMessage(MethodName, SendMessageOptions.DontRequireReceiver);
    }
}
