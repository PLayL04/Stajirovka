using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public event Action<Collider2D> TriggerEntered;
    public event Action<Collider2D> TriggerExited;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered?.Invoke(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExited?.Invoke(collision);
    }
}
