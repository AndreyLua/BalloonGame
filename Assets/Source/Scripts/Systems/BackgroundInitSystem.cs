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
        RenderedComponent rendered = new RenderedComponent(background.SpriteRenderer);
        ColorChangeCommand colorCommand = new ColorChangeCommand(new Color(0.0234f, 0.0039f,0.1953f), 200);

        backgroundEntity.Get<BackgroundTag>();
        backgroundEntity.Replace(model).Replace(colorCommand).Replace(rendered);
    }
}