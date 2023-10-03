using Leopotam.Ecs;
using UnityEngine;

public abstract class EntityMonoBehaviourBase : MonoBehaviour
{
    public abstract void Init(EcsEntity entity);
}
