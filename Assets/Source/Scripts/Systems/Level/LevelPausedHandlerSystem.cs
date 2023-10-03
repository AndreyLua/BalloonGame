using Leopotam.Ecs;
using UnityEngine;

public class LevelPausedHandlerSystem : IEcsRunSystem
{
    private EcsFilter<LevelTag, PausedEvent> _filter;

    private EcsFilter<ModelComponent> _filterModel;

    public void Run()
    {
        foreach (int i in _filter)
        {
            foreach (int j in _filterModel)
            {
                ref EcsEntity pausedEntity = ref _filterModel.GetEntity(j);
                pausedEntity.Get<Paused>();
            }
        }
    }
}
