using _Project.Core.GameField.FieldItems;
using _Project.Core.GameField.MatchCheck;
using UnityEngine;
using Zenject;

namespace _Project.Core.GameField
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

        Item item = _cellGrid.TryGet( origin ).Item;
        Item neighbourItem = _cellGrid.TryGet( neighbourCoords ).Item;

        return item.CanBeMatchedWith( neighbourItem );
    }

    void MoveAllItemsDownAndFillEmptySpots( MatchInfo matchInfo )
    {
        for ( int i = 0; i < matchInfo.ItemsCount; i++ ) //fix to more optimized
        {
            TryMoveAllItemsDownByOneStep();
        }

        for ( int i = 0; i < _cellGrid.Count; i++ ) //fix to more optimized
        {
            Cell cell = _cellGrid.TryGet( i );
            if ( cell.HasItem == false )
            {
                _itemFactory.CreateItem( cell );
            }
        }
    }

    void TryMoveAllItemsDownByOneStep( )
    {
        for ( int i = _cellGrid.Count - 1; i >= 0; i-- )
        {
            Cell cell = _cellGrid.TryGet( i );
            TryPullUpperItem( cell );
        }

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
        if ( cell == null || cell.HasItem )
            return;

        Cell upper = GetNeighbour( cell, Direction.Up );

        if ( upper == null || upper.HasItem == false )
            return;

        SwitchItems( cell, upper );
    }

    void SwitchItems( Cell cell, Cell other )
    {
        ( cell.Item, other.Item ) = ( other.Item, cell.Item );

        TryMoveAssignedItemToCell( cell );
        TryMoveAssignedItemToCell( other );
    }

    void TryMoveAssignedItemToCell( Cell cell )
    {
        if ( cell.Item != null )
            cell.Item.Movement.Move( cell.transform.position );

        //item.Cell =
    }

    Cell GetNeighbour( Cell origin, Direction direction )
    {
        Vector2Int neighbourCoordinate = origin.LocalCoord + direction;

        if ( _cellGrid.IsInBounds( neighbourCoordinate ) )
        {
            return _cellGrid.TryGet( neighbourCoordinate );
        }

        return null;
    }
}

}