using Leopotam.Ecs;
using UnityEngine;

public class GroundInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelConfig _levelConfig;

    public void Init()
    {
        EcsEntity groundEntity = _ecsWorld.NewEntity();

        Ground ground = Object.Instantiate(_levelConfig.GroundPrefab, _levelConfig.StartGroundPosition, Quaternion.identity);

        ModelComponent model = new ModelComponent(ground.transform);
        MoveableComponent moveable = new MoveableComponent(Vector2.down, _levelConfig.Speed);

        groundEntity.Get<GroundTag>();
        groundEntity.Replace(model).Replace(moveable);
    }
}
