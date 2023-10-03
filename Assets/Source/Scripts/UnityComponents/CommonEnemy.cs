using Leopotam.Ecs;
using UnityEngine;

public class CommonEnemy : EnemyBase
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public override EnemyType Identifier => EnemyType.Common;
    public override SpriteRenderer SpriteRenderer => _spriteRenderer;
}
