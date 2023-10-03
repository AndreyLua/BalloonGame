using Leopotam.Ecs;
using UnityEngine;

public class Balloon : EntityMonoBehaviourBase
{
    private Trigger2DChecker _trigger;
    private EcsEntity _ecsEntity;

    private void Awake()
    {
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
