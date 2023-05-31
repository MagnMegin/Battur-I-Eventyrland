using UnityEngine;
using UnityEngine.Events;

public class TestButtonSimple : MonoBehaviour
{
    public UnityEvent OnButtonPressed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          OnButtonPressed.Invoke();
        }
    }
}
