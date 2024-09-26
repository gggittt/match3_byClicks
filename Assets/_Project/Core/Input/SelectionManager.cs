using UnityEngine;

namespace _Project.Core
{
class SelectionManager
{
    readonly Board _board;

     public SelectionManager( Board board ) => _board = board;

     public void OnCellClick( Cell cell )
    {
        //here extend logic if требования changed to more common version match3, with item swipes

        _board.HandleClick( cell );
    }
    }
}