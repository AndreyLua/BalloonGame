using Leopotam.Ecs;
using UnityEngine;

public class RestartGroundSystem : IEcsRunSystem
{
    private LevelConfig _levelConfig;
    private EcsFilter<RestartEvent, GroundTag, ModelComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref GroundTag groundTag = ref _filter.Get2(i);
            ref ModelComponent model = ref _filter.Get3(i);

            MoveableComponent moveable = new MoveableComponent(Vector2.down, _levelConfig.Speed);

            entity.Replace(moveable);
            model.Transform.position = _levelConfig.StartGroundPosition;
        }
    }
}
