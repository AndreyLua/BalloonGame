using System;
using UnityEngine;

public class Trigger2DChecker : MonoBehaviour
{
    public event Action<Collider2D> TriggerEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered?.Invoke(collision);
    }
}
