using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private BalloonConfig _balloonConfig;

    public void Init()
    {
        EcsEntity playerEntity = _ecsWorld.NewEntity();

        Balloon balloon = Object.Instantiate(_balloonConfig.Prefab, _balloonConfig.StartPosition, Quaternion.identity);

        ModelComponent model = new ModelComponent(balloon.transform);
        LineComponent line = new LineComponent(LineType.Middle);

        playerEntity.Get<PlayerTag>();
        playerEntity.Replace(model).Replace(line);

        balloon.Init(playerEntity);
      }
}
