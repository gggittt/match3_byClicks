using _Project.Core.GameField;
using UnityEngine;
using Zenject;

namespace _Project.Core
{

public class EntryPointGameplay : MonoBehaviour
{
    [Inject] CellCreator _cellCreator;
    [Inject] Board _board;
    [Inject] Turns _turns;
    [Inject] GameOver _gameOver;

    void Start( )
    {
        _cellCreator.CreateBoard();
        _board.PopulateBoard();

        _turns.Spend += _gameOver.Check;
    }

}

}