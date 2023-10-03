internal struct LineChangedEvent
{
    public LineType LineType;

    public LineChangedEvent(LineType lineType)
    {
        LineType = lineType;
    }
}
