using Leopotam.Ecs;
using UnityEngine;

public class ChangeLineSystem : IEcsRunSystem
{
    private EcsFilter<ChangeLineCommand, LineComponent> _filter;

    public void Run()
    {
        foreach (int i in _filter)
        {
            ref ChangeLineCommand command = ref _filter.Get1(i);
            ref LineComponent line = ref _filter.Get2(i);
           
            if (CheckIsLineCommandDoable(command, line))
            {
                int offsetValue = (command.ChangeLineCommandType == ChangeLineCommandType.Left) ? (-1) : (1);

                line.LineType = (LineType)((int)line.LineType + offsetValue);
                ref EcsEntity entity =  ref _filter.GetEntity(i);

                LineChangedEvent lineChangedEvent = new LineChangedEvent(line.LineType);
                entity.Replace(lineChangedEvent);
            }
        }
    }

    private bool CheckIsLineCommandDoable(ChangeLineCommand command, LineComponent line)
    {
        if (line.LineType == LineType.Left && command.ChangeLineCommandType == ChangeLineCommandType.Left)
            return false;

        if (line.LineType == LineType.Right && command.ChangeLineCommandType == ChangeLineCommandType.Right)
            return false;

        return true;
    }
}
