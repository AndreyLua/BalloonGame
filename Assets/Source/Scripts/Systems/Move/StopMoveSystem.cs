using Leopotam.Ecs;

public class StopMoveSystem : IEcsRunSystem
{
    private EcsFilter<ModelComponent, MoveableComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref ModelComponent model = ref _filter.Get1(i);

            if (model.Transform.position.y < -7)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                entity.Del<MoveableComponent>();
                entity.Get<MoveStoppedEvent>();
            }
        }
    }
}
