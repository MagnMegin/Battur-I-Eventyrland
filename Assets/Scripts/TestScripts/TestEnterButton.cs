using UnityEngine;
using UnityEngine.Events;

public class TestEnterButton : MonoBehaviour
{
    public UnityEvent OnButtonPressed;
    public bool PlayerInRange;

    private void Start()
    {
        PlayerInRange = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
    private void Update()
    {
        if ((PlayerInRange == true) && Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonPressed.Invoke();
        }
    }
}
