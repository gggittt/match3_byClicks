using _Project.Core.GameField.MatchCheck;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
class Board : MonoBehaviour
{
    [Inject] CellGrid<Cell> _cellGrid;
    [Inject] ItemFactory _itemFactory;
    [Inject] MatchChecker _matchChecker;

    public Board( CellGrid<Cell> cellGrid, ItemFactory itemFactory, MatchChecker matchChecker )
    {
        _cellGrid = cellGrid;
        _itemFactory = itemFactory;
        _matchChecker = matchChecker;
    }

    public void FillBoard( )
    {
        foreach ( Cell cell in _cellGrid.Cells )
        {
            _itemFactory.CreateItem( cell );
        }
    }

    public void HandleClick( Cell cell )
    {
        _matchChecker.CheckAllDirectionsAtPoint( cell.LocalCoord );
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

}

}