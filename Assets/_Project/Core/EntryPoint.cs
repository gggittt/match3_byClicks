using _Project.Core.GameField;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
public class EntryPoint : MonoBehaviour
{
    [Inject] CellCreator _cellCreator;
    [Inject] Board _board;

    void Start( )
    {
        _cellCreator.CreateBoard();
        _board.PopulateBoard();
    }

}

}