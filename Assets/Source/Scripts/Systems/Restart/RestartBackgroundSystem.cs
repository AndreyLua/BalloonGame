using Leopotam.Ecs;
using UnityEngine;

public class RestartBackgroundSystem : IEcsRunSystem
{
    private EcsFilter<RestartEvent, BackgroundTag, RenderedComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref RenderedComponent renderer = ref _filter.Get3(i);

            renderer.SpriteRenderer.color = new Color(0.789f, 0.945f, 0.996f);
            ColorChangeCommand colorCommand = new ColorChangeCommand(new Color(0.0234f, 0.0039f, 0.1953f), 50);

            entity.Replace(colorCommand);
        }
    }
}
