using Leopotam.Ecs;
using UnityEngine;

public class Balloon : EntityMonoBehaviourBase
{
    private Trigger2DChecker _trigger;

    private void Awake()
    {
        _trigger = gameObject.GetComponentInChildren<Trigger2DChecker>();
        _trigger.TriggerEntered += OnTriggerEntered; 
    }

    public void OnTriggerEntered(Collider2D collider)
    {
        Debug.Log("fdjklfsdjlsfjlkd");
    }

    public override void Init(EcsEntity entity)
    {
       
    }
}
