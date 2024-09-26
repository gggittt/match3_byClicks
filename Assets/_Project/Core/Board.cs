using Zenject;

namespace _Project.Core
{
class Board
{
    readonly CellGrid<Cell> _cellGrid;
    readonly ItemFactory _itemFactory;

    public Board( CellGrid<Cell> cellGrid, ItemFactory itemFactory )
    {
        _cellGrid = cellGrid;
        _itemFactory = itemFactory;
    }

    public void FillBoard( )
    {
        foreach ( Cell cell in _cellGrid.Cells )
        {
            _itemFactory.CreateItem( cell );
        }
    }

}
}