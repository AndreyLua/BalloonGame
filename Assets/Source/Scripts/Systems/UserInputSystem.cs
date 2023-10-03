using Leopotam.Ecs;
using UnityEngine;

public class UserInputSystem : IEcsRunSystem
{
    private UserInputConfig _userInputConfig;
    private EcsFilter<PlayerTag> _filter;

    private Vector2 _startSleshPosition;
    private bool _isMouseHold;

    public void Run()
    {
        if (Input.GetMouseButtonDown(0) && _isMouseHold == false)
        {
            _isMouseHold = true;
            _startSleshPosition = Input.mousePosition;
        }
     
        if (Input.GetMouseButtonUp(0))
        {
            _isMouseHold = false;
            if (CheckSwipeValid())
            {
                ChangeLineCommand inputData = new ChangeLineCommand();

                InitializePlayerInputData(ref inputData);
                SendPlayerInputData(ref inputData);
            }
        }
    }

    private bool CheckSwipeValid()
    {
        return Mathf.Abs(Input.mousePosition.x - _startSleshPosition.x) >= _userInputConfig.SwipeLength;
    }

    private void InitializePlayerInputData(ref ChangeLineCommand inputData)
    {
        if (Input.mousePosition.x > _startSleshPosition.x)
            inputData.ChangeLineCommandType = ChangeLineCommandType.Right;
        else
            inputData.ChangeLineCommandType = ChangeLineCommandType.Left;
    }

    private void SendPlayerInputData(ref ChangeLineCommand data)
    {
        foreach (int i in _filter)
        {
            ref EcsEntity player = ref _filter.GetEntity(i);
            player.Replace(data);
        }
    }
}
