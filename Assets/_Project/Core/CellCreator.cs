using _Scripts.Field;
using _Scripts.Field.Cells;
using _Scripts.PersistentProgress;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
public class CellCreator : MonoBehaviour
{
    [Inject] GameData _gameData;
    [Inject] CellGrid<Cell> _cellGrid;

    [SerializeField] Cell _cellPrefab;

    //start at top left position
    public void CreateBoard( /*Vector2Int gridSize*/ )
    {
        Vector2Int gridSize = _gameData.BoardSize;
        Vector3 cellLocalScale = _cellPrefab.transform.localScale;

        for ( int y = 0; y < gridSize.y; y++ )
        for ( int x = 0; x < gridSize.x; x++ )
        {
            CreateTile( x, y, cellLocalScale );
        }
    }

    void CreateTile( int x, int y, Vector3 cellLocalScale )
    {
        Cell cell = Instantiate( _cellPrefab, transform ); //get from pool
        cell.Init( new ( x, y ) );
        _cellGrid.Set( x, y, cell );

        SetCellPosition();
        void SetCellPosition( )
        {
            const int worldToLocalCoefficient = - 1; //revertCreationTopToBotton
            float xPos = x * cellLocalScale.x;
            float yPos = worldToLocalCoefficient * y * cellLocalScale.y;
            Vector3 shiftFromPreviousCell = new(xPos, yPos);

            cell.transform.position = transform.position + shiftFromPreviousCell;
        }
    }

}
}