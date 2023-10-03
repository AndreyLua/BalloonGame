using DG.Tweening;
using Leopotam.Ecs;

public class ChangeColorSystem : IEcsRunSystem
{
    private EcsFilter<ColorChangeCommand, RenderedComponent> _filter;
    private EcsFilter<ChangingColorComponent, Paused> _pausedFilter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref ColorChangeCommand colorComponent = ref _filter.Get1(i);
            ref RenderedComponent renderer = ref _filter.Get2(i);

            Tweener _colorTweener = renderer.SpriteRenderer.DOColor
                (colorComponent.FinalColor, colorComponent.Duration);

            entity.Del<ColorChangeCommand>();

            ChangingColorComponent changingColorComponent = new ChangingColorComponent(_colorTweener);
            entity.Replace(changingColorComponent);
        }

        foreach (int i in _pausedFilter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref ChangingColorComponent colorComponent = ref _pausedFilter.Get1(i);
            colorComponent.Tweener.Kill();
            entity.Del<ChangingColorComponent>();
        }
    }
}
