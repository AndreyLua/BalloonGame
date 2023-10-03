using Leopotam.Ecs;
using UnityEngine;

public class BalloonInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private BalloonConfig _balloonConfig;

    public void Init()
    {
        EcsEntity balloonEntity = _ecsWorld.NewEntity();

        Balloon balloon = Object.Instantiate(_balloonConfig.Prefab, _balloonConfig.StartPosition, Quaternion.identity);

        ModelComponent model = new ModelComponent(balloon.transform);
        LineComponent line = new LineComponent(LineType.Middle);

        balloonEntity.Get<PlayerTag>();
        balloonEntity.Replace(model).Replace(line);

        balloon.Init(balloonEntity);
      }
}
