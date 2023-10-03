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

        Injects();
        OneFrames();
        AddSystems();
        _systems.Init();
    }       

    private void Injects()
    {
        _systems
           .Inject(_userInputConfig)
           .Inject(_balloonConfig)
           .Inject(_levelConfig)
           .Inject(_enemiesConfig);
    }

    private void OneFrames()
    {
        _systems
            .OneFrame<ChangeLineCommand>()
            .OneFrame<LineChangedEvent>()
            .OneFrame<MoveStoppedEvent>()
            .OneFrame<RestartEvent>()
            .OneFrame<PauseEvent>();
    }

    private void AddSystems()
    {
        _systems
            .Add(new BackgroundInitSystem())
            .Add(new PlayerInitSystem())
            .Add(new GroundInitSystem())
            .Add(new UserInputSystem())
            .Add(new PlayerDiedEventHandler())
            .Add(new ChangeLineSystem())
            .Add(new LineChangeHandlerSystem())
            .Add(new MoveSystem())
            .Add(new SpawnEnemiesSystem())
            .Add(new StopMoveSystem())
            .Add(new EnemyMoveStoppedHandlerSystem())
            .Add(new RestartEnemiesSystem())
            .Add(new RestartGroundSystem())
            .Add(new ChangeColorSystem())
            .Add(new RestartBackgroundSystem())
            .Add(new RestartPlayerSystem());
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

