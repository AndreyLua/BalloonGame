using Leopotam.Ecs;
using UnityEngine;

public class BackgroundInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelConfig _levelConfig;

    public void Init()
    {
        EcsEntity backgroundEntity = _ecsWorld.NewEntity();

        Background background = Object.Instantiate(_levelConfig.Background, _levelConfig.StartBackgroundPosition, Quaternion.identity);

        ModelComponent model = new ModelComponent(background.transform);
        ColorChangeCommand color = new ColorChangeComponent(new Color(202, 242, 255),new Color(6,1,50),
            background.SpriteRenderer, 2);
       
        backgroundEntity.Replace(model).Replace(color);
    }
}