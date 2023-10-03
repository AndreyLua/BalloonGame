using Leopotam.Ecs;

public class RestartPlayerSystem : IEcsRunSystem
{
    private BalloonConfig _balloonConfig;

    private EcsFilter<RestartEvent, PlayerTag, LineComponent, ModelComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref EcsEntity entity = ref _filter.GetEntity(i);
            ref LineComponent lineComponent = ref _filter.Get3(i);
            ref ModelComponent model = ref _filter.Get4(i);

            lineComponent.LineType = LineType.Middle;
            model.Transform.position = _balloonConfig.StartPosition;
        }
    }
}