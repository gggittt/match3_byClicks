using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Extensions.Enumerable;
using UnityEngine;

namespace _Project.Core.GameField.MatchCheck
{
public class MatchChecker
{
    // readonly Func<Vector2Int, Direction, bool> _isNeighborSameShape;
    Board _board;
    readonly MatchReaper _matchReaper;
    readonly GameData _gameData;

    public MatchChecker( Board board, MatchReaper matchReaper, GameData gameData )
    {
        _board = board;
        _matchReaper = matchReaper;
        _gameData = gameData;
    }
    // public MatchChecker( Func<Vector2Int, Direction, bool> isNeighborSameShape, MatchReaper matchReaper, GameData gameData )
    // {
    //     _isNeighborSameShape = isNeighborSameShape;
    //     _matchReaper = matchReaper;
    //     _gameData = gameData;
    // }

    public MatchInfo HandleComboAtPoint( Vector2Int startPoint )
    {
        MatchInfo matchInfo = _gameData.MatchType switch
        {
            MatchCheckType.AllOrthogonalNeighbours =>
                GetMatchOfAnyConnectedWithConsistentlySameShape( startPoint ),
            MatchCheckType.OrthogonalNeighboursOnlyInLineInSameLineOrRow =>
                GetMatchInLinesOfConsistentlySameShape( startPoint ),
            _ => throw new ArgumentOutOfRangeException()
        };

        _matchReaper.Reap( matchInfo );

        return matchInfo;
    }

    MatchInfo GetMatchOfAnyConnectedWithConsistentlySameShape( Vector2Int startPoint )
    {
        MatchInfo matchInfo = new(startPoint);
        ICollection<Vector2Int> closedList = new List<Vector2Int>();
        // ICollection<Vector2Int> suitableList = new List<Vector2Int>(); // мб сразу matchInfo.AllSuitableItems;

        AddNeighbourOfAnyConnectedWithConsistentlySameShape( startPoint, closedList, matchInfo );

        return matchInfo;
    }

    void AddNeighbourOfAnyConnectedWithConsistentlySameShape( Vector2Int coords, ICollection<Vector2Int> closedList, MatchInfo matchInfo )
    {
        foreach ( Direction direction in Direction.Orthogonal )
        {
            Vector2Int current = coords + direction;

            if ( closedList.Contains( current ) )
            {
                continue;
            }

            bool isNeighborSuitable = _board.IsNeighborSameShape( coords, direction );
            // bool isNeighborSuitable = _isNeighborSameShape( coords, direction );

            closedList.Add( current );

            if ( isNeighborSuitable == false )
            {
                continue;
            }

            matchInfo.Add( current );
            AddNeighbourOfAnyConnectedWithConsistentlySameShape( coords + direction, closedList, matchInfo );
        }
    }

    MatchInfo GetMatchInLinesOfConsistentlySameShape( Vector2Int startPoint )
    {
        MatchInfo matchInfo = new(startPoint);

        HashSet<Vector2Int> left = GetNeighboursInLineOfConsistentlySameShape( Direction.Left, startPoint );
        HashSet<Vector2Int> right = GetNeighboursInLineOfConsistentlySameShape( Direction.Right, startPoint );
        HashSet<Vector2Int> horizontal = left.CombineWith( right );

        HashSet<Vector2Int> top = GetNeighboursInLineOfConsistentlySameShape( Direction.Up, startPoint );
        HashSet<Vector2Int> bottom = GetNeighboursInLineOfConsistentlySameShape( Direction.Down, startPoint );
        HashSet<Vector2Int> vertical = top.CombineWith( bottom );

        //Здесь уточнить логику. если для добавления бонусного хода должно быть именно 3 одной линией, то здесь проверять if (horizontal.Count >= minComboSize) ... иначе в комбо будет записываться и уголок в 3 клетки, где прямая линия = макс 2 клетки.

        matchInfo.Add( horizontal );
        matchInfo.Add( vertical );

        return matchInfo;
    }

    HashSet<Vector2Int> GetNeighboursInLineOfConsistentlySameShape( Direction direction, Vector2Int coords )
    {
        HashSet<Vector2Int> suitableInHalfLine = new();

        AddAllSuitableInLine( coords, direction, suitableInHalfLine );

        return suitableInHalfLine;
    }

    void AddAllSuitableInLine( Vector2Int coords, Direction direction, ICollection<Vector2Int> suitableLine )
    {
        // bool isNeighborSuitable = _isNeighborSameShape( coords, direction );
        bool isNeighborSuitable = _board.IsNeighborSameShape( coords, direction );

        if ( isNeighborSuitable == false )
        {
            return;
        }

        Vector2Int neighbour = coords + direction;

        suitableLine.Add( neighbour );
        AddAllSuitableInLine( neighbour, direction, suitableLine );
    }
}
}