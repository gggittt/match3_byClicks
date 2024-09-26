using System.Collections.Generic;
using UnityEngine;

namespace _Project.Core.GameField.MatchCheck
{
public class MatchReaper //MatchCollector
{
    readonly CellGrid<Cell> _cellGrid;
    readonly GameData _data;
    readonly ObjectsPoolGeneric<Item> _objectsPool;

    public MatchReaper( CellGrid<Cell> cellGrid, GameData data, ObjectsPoolGeneric<Item> objectsPool )
    {
        _cellGrid = cellGrid;
        _data = data;
        _objectsPool = objectsPool;
    }

    public void Reap( MatchInfo matchInfo )
    {
        Debug.Log( $"{matchInfo}" );

        int itemCount = matchInfo.AllSuitableItems.Count;
        if ( itemCount < 1 )
            return;

        foreach ( Vector2Int element in matchInfo.AllSuitableItems )
        {
            Item item = _cellGrid.Get( element ).Item;
            _objectsPool.Release( item );

            _cellGrid.Get( element ).Item = null;
            // _objectsPool.Release( item );
        }

        _data.AddBonusTurns( GetBonusTurnsFor( itemCount ) );
    }

    int GetBonusTurnsFor( int itemCount )
    {
        return itemCount - 1;
    }

}
}