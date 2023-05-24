using System;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public Action<bool> OnHouseEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Thief>(out Thief thief)) 
        {
            OnHouseEntered?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.TryGetComponent<Thief>(out Thief thief))
        {
            OnHouseEntered?.Invoke(false);
        }
    }
}
