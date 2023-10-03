using Leopotam.Ecs;

public class LevelRestartHandlerSystem : IEcsRunSystem
{
    private EcsFilter<LevelTag, RestartLevelEvent> _filter;

    private EcsFilter<ModelComponent> _filterModel;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity levelEntity = ref _filter.GetEntity(i);
            foreach (int j in _filterModel)
            {
                ref EcsEntity restartedEntity = ref _filterModel.GetEntity(j);
                restartedEntity.Get<RestartEvent>();
                restartedEntity.Del<Paused>();
            }
            levelEntity.Del<RestartLevelEvent>();
        }
    }
}
