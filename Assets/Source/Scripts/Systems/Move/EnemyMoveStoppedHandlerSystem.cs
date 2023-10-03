using Leopotam.Ecs;

public class EnemyMoveStoppedHandlerSystem : IEcsRunSystem
{
    private EcsFilter<MoveStoppedEvent, EnemyTag> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EnemyTag tag = ref _filter.Get2(i);
            ref EcsEntity entity = ref _filter.GetEntity(i);
            
            tag.EnemyBase.ReturnEnemyInPool();
            entity.Destroy();
        }
    }
}

