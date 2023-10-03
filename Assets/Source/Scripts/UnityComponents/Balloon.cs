using Leopotam.Ecs;
using UnityEngine;

public class Balloon : EntityReference
{
    private Rigidbody2D _rigidbody2D;
    private Trigger2DChecker _trigger;
    private EcsEntity _ecsEntity;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _trigger = gameObject.GetComponentInChildren<Trigger2DChecker>();
        _trigger.TriggerEntered += OnTriggerEntered; 
    }

    public void OnTriggerEntered(Collider2D collider)
    {
        _ecsEntity.Get<PlayerDiedEvent>();
    }

    public override void Init(EcsEntity entity)
    {
        _ecsEntity = entity;
    }
}
