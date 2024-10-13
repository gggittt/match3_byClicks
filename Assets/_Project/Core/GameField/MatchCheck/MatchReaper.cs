using System.Collections.Generic;
using _Project.Core.GameField.FieldItems;
using _Project.Core.Pool;
using UnityEngine;
using Zenject;

namespace _Project.Core.GameField.MatchCheck
{
public class MatchReaper //MatchCollector
{
    [Inject] CellGrid<Cell> _cellGrid;
    [Inject] ObjectsPool<Item> _objectsPool;
    [Inject] Turns _turns;

    // public MatchReaper( CellGrid<Cell> cellGrid, Turns turns, ObjectsPool<Item> objectsPool )
    // {
    //     _cellGrid = cellGrid;
    //     _turns = turns;
    //     _objectsPool = objectsPool;
    // }

    // public MatchReaper( Turns turns )
    // {
    //     _turns = turns;
    // }

    public void Reap( MatchInfo matchInfo )
    {
        Debug.Log( $"{matchInfo}" );

        int itemCount = matchInfo.AllSuitableItems.Count;
        if ( itemCount < 1 )
        {
            return;
        }

        foreach ( Vector2Int element in matchInfo.AllSuitableItems )
        {
            Item item = _cellGrid.TryGet( element ).Item;
            _objectsPool.Release( item );

            _cellGrid.TryGet( element ).Item = null;
        }

        _turns.Add(  GetBonusTurnsFor( itemCount ) );
    }

    int GetBonusTurnsFor( int itemCount )
    {
        return itemCount - 1;
    }

}
}