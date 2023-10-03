using Leopotam.Ecs;

public class LevelInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;

    public void Init()
    {
        EcsEntity levelEntity = _ecsWorld.NewEntity();

        levelEntity.Get<LevelTag>();
    }
}
