using Leopotam.Ecs;

public class PlayerDiedEventHandler : IEcsRunSystem
{
    private EcsFilter<PlayerDiedEvent, ModelComponent> _filter;
    private EcsFilter<ModelComponent> _filterRestartedElements;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            entity.Del<PlayerDiedEvent>();
            RestartLevel();
            return;
        }
    }

    private void RestartLevel()
    {
        foreach (int i in _filterRestartedElements)
        {
            ref EcsEntity restartedEntity = ref _filterRestartedElements.GetEntity(i);
            restartedEntity.Get<RestartedEvent>();
        }
    }
}
