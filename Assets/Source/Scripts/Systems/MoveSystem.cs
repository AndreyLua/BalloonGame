using DG.Tweening;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    private EcsFilter<ModelComponent, MoveableComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref ModelComponent model = ref _filter.Get1(i);
            ref MoveableComponent moveable = ref _filter.Get2(i);

            model.Transform.position += (Vector3)moveable.Direction * moveable.Speed * Time.deltaTime;
        }
    }
}

public class ChangeColorSystem : IEcsRunSystem
{
    private EcsFilter<ColorChangeCommand>.Exclude<RestartedEvent> _filter;
    private EcsFilter<ChangingColorComponent,RestartedEvent> _restartedFilter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref ColorChangeCommand colorComponent = ref _filter.Get1(i);

            Tweener _colorTweener = colorComponent.SpriteRenderer.DOColor
                (colorComponent.FinalColor, colorComponent.Duration);

            ChangingColorComponent changingColorComponent = new ChangingColorComponent(_colorTweener);

            entity.Replace(changingColorComponent);
        }

        foreach (int i in _restartedFilter)
        {
            ref ChangingColorComponent colorComponent = ref _restartedFilter.Get1(i);
            colorComponent.Tweener.Kill();
        }
    }
}
