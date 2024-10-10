using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Extensions.Enumerable;

namespace _Project.Core.GameField
{
public class ShapeTypes
{
    readonly List<ShapeType> _cantBeRandom = new() { ShapeType.None };
    readonly List<ShapeType> _allowedToSpawnTypes;

    public List<ShapeType> NotNoneTypes { get; private set; }

    public ShapeType RandomAllowedToSpawnType => _allowedToSpawnTypes.GetRandom();


    public ShapeTypes( ShapeType allShapesAsFlag )
    {
        NotNoneTypes = Enum.GetValues( typeof( ShapeType ) )
           .Cast<ShapeType>()
           .Where( x => x != ShapeType.None )
           .ToList();

        _allowedToSpawnTypes = CalculateAllowedShapesForRandomSpawn( allShapesAsFlag );
    }

    public List<ShapeType> CalculateAllowedShapesForRandomSpawn( ShapeType allowedShapesAsRandom )
    {
        List<ShapeType> result = new();

        List<ShapeType> allowed = allowedShapesAsRandom.ToList();

        foreach ( ShapeType value in allowed )
        {
            if ( _cantBeRandom.Contains( value ) == false )
                result.Add( value );
        }

        return result;
    }
}

}