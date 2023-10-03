using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IPoolable<EnemyBase, EnemyType>
{
    public abstract SpriteRenderer SpriteRenderer { get; }

    public abstract EnemyType Identifier { get; }

    public event Action<EnemyBase> ElementReturnEvent;
    public event Action<EnemyBase> ElementDestroyEvent;

    public void ReturnEnemyInPool()
    {
        gameObject.SetActive(false);
        ElementReturnEvent?.Invoke(this);
    }

    public void DestroyEnemyInPool()
    {
        ElementDestroyEvent?.Invoke(this);
    }
}