using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    [SerializeField] private BalloonConfig _balloonConfig;
    [SerializeField] private UserInputConfig _userInputConfig;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private EnemiesConfig _enemiesConfig;

    private EcsWorld _ecsWorld;
    private EcsSystems _systems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _systems = new EcsSystems(_ecsWorld);

        _systems
            .Inject(_userInputConfig)
            .Inject(_balloonConfig)
            .Inject(_levelConfig)
            .Inject(_enemiesConfig)
            
            .OneFrame<ChangeLineCommand>()
            .OneFrame<LineChangedEvent>()

            .Add(new BalloonInitSystem())
            .Add(new GroundInitSystem())
            .Add(new UserInputSystem())
            .Add(new ChangeLineSystem())
            .Add(new LineChangeHandlerSystem())
            .Add(new MoveSystem())
            .Add(new SpawnEnemiesSystem())

            .Init();
    }       

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        _systems?.Destroy();
        _systems = null;
        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}

