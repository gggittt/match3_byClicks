using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Core.GameField;
using _Project.Core.GameField.MatchCheck;
using _Project.Extensions.UnityTypes;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
public class Board : MonoBehaviour
{
    [Inject] CellGrid<Cell> _cellGrid;
    [Inject] ItemFactory _itemFactory;
    [Inject] MatchChecker _matchChecker;
    [Inject] GameData _gameData;

    public void HandleClick( Cell cell )
    {
        MatchInfo matchInfo = _matchChecker.HandleComboAtPoint( cell.LocalCoord );

        MoveAllItemsDownAndFillEmptySpots( matchInfo );
    }

    public void PopulateBoard( ) //override all items, if they were
    {
        foreach ( Cell cell in _cellGrid.Cells )
        {
            Item item = _itemFactory.CreateItem( cell );
            item.transform.parent = cell.transform;
        }
    }

    public bool IsNeighborSameShape( Vector2Int origin, Direction shift )
    {
        Vector2Int neighbourCoords = origin + shift;
        bool inBounds = _cellGrid.IsInBounds( neighbourCoords );
        if ( inBounds == false )
        {
            return false;
        }

        Item item = _cellGrid.Get( origin ).Item;
        Item neighbourItem = _cellGrid.Get( neighbourCoords ).Item;

        return item.CanBeMatchedWith( neighbourItem );
    }

    void MoveAllItemsDownAndFillEmptySpots( MatchInfo matchInfo )
    {
        foreach ( Vector2Int coordinate in matchInfo.AllSuitableItems )
        {
            TryMoveAllItemsDownByOneStep();

            Cell cell = _cellGrid.Get( coordinate );
            Item item = _itemFactory.CreateItem( cell );
            // item.View.MoveDownWhileBottomIsEmpty();

            item.transform.parent = cell.transform;
        }
    }

    void TryMoveAllItemsDownByOneStep( )
    {

        for ( int i = _cellGrid.Cells.Length; i > 0; i-- )
        {
            // IEnumerable<Cell> enumerable = _cellGrid.Cells.Reverse();
            Cell cell = _cellGrid.Cells[ i ];
            TryPullUpperItem( cell );
        }

        // foreach ( Cell cell in _cellGrid.Cells )
        // {
        //     if ( cell.HasItem == false )
        //         continue;

        //
        //     MoveItem( from: upper, Direction.Down );
        // }

        // while ( _cellGrid.Get( coordinate ).Empty )
        /*  foreach ( Vector2Int coordinate in matchInfo.AllSuitableItems
            1. shift all upper down
                    if they exist, мб весь ряд удалён

            2. get all empty spot вверху
            3. foreach.create new дальше можно даже без анимации создать?
         */
    }

    void TryPullUpperItem( Cell cell )
    {
        if ( cell.HasItem )
            return;

        Cell upper = GetNeighbour( cell, Direction.Up );

        if ( upper == null || upper.HasItem == false )
            return;

        SwitchItems( cell, upper );
    }

    void SwitchItems( Cell cell, Cell other )
    {
        ( cell.Item, other.Item ) = ( other.Item, cell.Item );
        //item.Cell =
    }


    public Cell GetNeighbour( Cell origin, Direction direction )
    {
        Vector2Int neighbourCoordinate = origin.LocalCoord + direction;

        if ( _cellGrid.IsInBounds( neighbourCoordinate ) )
        {
            return _cellGrid.Get( neighbourCoordinate );
        }

        return null;
    }

    bool IsYInBoundsAndEmpty( Vector2Int coordinate )
    {
        return _cellGrid.IsYInBounds( coordinate.y ) && _cellGrid.Get( coordinate ).Empty;
    }

}

}