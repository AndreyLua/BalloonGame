using DG.Tweening;
using Leopotam.Ecs;

public class LineChangeHandlerSystem : IEcsRunSystem
{
    private LevelConfig _levelConfig;
    private EcsFilter<LineChangedEvent, ModelComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref LineChangedEvent lineChangedEvent = ref _filter.Get1(i);
            ref ModelComponent model = ref _filter.Get2(i);

            float newPositionX = _levelConfig.LineXPositionInTypePair[lineChangedEvent.LineType];
         
            model.Transform.DOMoveX(newPositionX, 1);
        }
    }
}
