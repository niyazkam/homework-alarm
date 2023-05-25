using System;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public event Action<bool> BrokeIntoHouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Thief>(out Thief thief)) 
            BrokeIntoHouse?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Thief>(out Thief thief))
            BrokeIntoHouse?.Invoke(false);
    }
}
