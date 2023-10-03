using Leopotam.Ecs;

public class PlayerDiedEventHandler : IEcsRunSystem
{
    private EcsFilter<PlayerDiedEvent, ModelComponent> _filter;
    private EcsFilter<ModelComponent> _filterModel;

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
        foreach (int i in _filterModel)
        {
            ref EcsEntity restartedEntity = ref _filterModel.GetEntity(i);
            restartedEntity.Get<PauseEvent>();
        }

        foreach (int i in _filterModel)
        {
            ref EcsEntity restartedEntity = ref _filterModel.GetEntity(i);
            restartedEntity.Get<RestartEvent>();
        }
    }
}
