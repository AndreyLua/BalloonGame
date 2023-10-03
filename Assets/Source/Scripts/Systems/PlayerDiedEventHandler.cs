using DG.Tweening;
using Leopotam.Ecs;

public class PlayerDiedEventHandler : IEcsRunSystem
{
    private EcsFilter<PlayerDiedEvent, ModelComponent> _filter;
    private EcsFilter<LevelTag> _filterLevel;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            entity.Del<PlayerDiedEvent>();
            PausedLevel();
            break;
        }
    }

    private void PausedLevel()
    {
        foreach (int i in _filterLevel)
        {
            ref EcsEntity entity = ref _filterLevel.GetEntity(i);
            entity.Get<PausedEvent>();
        }
        DOTween.Sequence().AppendInterval(3).AppendCallback(() =>
        {
            foreach (int i in _filterLevel)
            {
                ref EcsEntity entity = ref _filterLevel.GetEntity(i);
                entity.Get<RestartLevelEvent>();
            }
        });
    }
}
