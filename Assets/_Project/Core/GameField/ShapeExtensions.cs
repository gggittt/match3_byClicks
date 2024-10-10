using System;
using System.Collections.Generic;
using System.Linq;

namespace _Project.Core.GameField
{
public static class ShapeExtensions
{
    public static bool ContainsAny( this ShapeType @enum, ShapeType flags )
    {
        return ( @enum & flags ) > 0;
    }

    public static List<ShapeType> ToList( this ShapeType flag )
    {
        return Enum.GetValues( typeof( ShapeType ) )
           .Cast<ShapeType>()
           .Where( e => ( e & flag ) == e )
           .ToList();
    }
}
}