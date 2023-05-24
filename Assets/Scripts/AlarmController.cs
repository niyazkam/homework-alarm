using System;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    public event EventHandler OnHouseEntered;
    public event EventHandler OnHouseExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Thief>(out Thief thief)) 
        {
            OnHouseEntered?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Thief>(out Thief thief))
        {
            OnHouseExited?.Invoke(this, EventArgs.Empty);
        }
    }
}
