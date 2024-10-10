using System;

namespace _Project.Core.GameField
{
[Flags]
public enum ShapeType //Not "ColorType" because could be redCandy, redCookie, ... - it's not color, but shapeType / itemType
{
    None = 0,
    Red = 1, Green = 2, Blue = 4,
    Yellow = 8, Pink = 16, Cyan = 32,
    All = ~None,
}
}