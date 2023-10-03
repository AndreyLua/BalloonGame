using DG.Tweening;
using Leopotam.Ecs;
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
