using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Extensions.Enumerable;
using UnityEngine;

namespace _Project.Core.GameField.MatchCheck
{
class MatchChecker
{
    readonly Func<Vector2Int, Direction, bool> _isNeighborSameShape;
    readonly MatchReaper _matchReaper;

    public MatchChecker( Func<Vector2Int, Direction, bool> isNeighborSameShape, MatchReaper matchReaper )
    {
        _isNeighborSameShape = isNeighborSameShape;
        _matchReaper = matchReaper;
    }

    public MatchInfo HandleComboAtPoint( Vector2Int startPoint ) //CheckAllDirectionsAtPoint
    {
        MatchInfo matchInfo = CheckMatchAt( startPoint );
        _matchReaper.Reap( matchInfo );

        return matchInfo;
    }

    MatchInfo CheckMatchAt( Vector2Int startPoint )
    {
        MatchInfo matchInfo = new(startPoint);

        HashSet<Vector2Int> left = GetNeighboursOfConsistentlySameShape( Direction.Left, startPoint );
        HashSet<Vector2Int> right = GetNeighboursOfConsistentlySameShape( Direction.Right, startPoint );
        HashSet<Vector2Int> horizontal = left.CombineWith( right );

        HashSet<Vector2Int> top = GetNeighboursOfConsistentlySameShape( Direction.Up, startPoint );
        HashSet<Vector2Int> bottom = GetNeighboursOfConsistentlySameShape( Direction.Down, startPoint );
        HashSet<Vector2Int> vertical = top.CombineWith( bottom );

        //Здесь уточнить логику. если для доп хода должно быть именно 3 одной линией, то здесь проверять if (horizontal.Count >= minComboSize) ... иначе в комбо будет записываться и уголок в 3 клетки, где прямая линия = макс 2 клетки.

        matchInfo.Add( horizontal );
        matchInfo.Add( vertical );

        return matchInfo;
    }

    HashSet<Vector2Int> GetNeighboursOfConsistentlySameShape( Direction direction, Vector2Int coords )
    {
        HashSet<Vector2Int> suitableInHalfLine = new();

        CheckNeighbour( coords, direction, suitableInHalfLine );

        return suitableInHalfLine;
    }

    void CheckNeighbour( Vector2Int origin, Direction direction, ICollection<Vector2Int> suitableLine )
    {
        bool isNeighborSuitable = _isNeighborSameShape( origin, direction );

        if ( isNeighborSuitable == false )
            return;

        Vector2Int neighbour = origin + direction;

        suitableLine.Add( neighbour );
        CheckNeighbour( neighbour, direction, suitableLine );
    }
}


}