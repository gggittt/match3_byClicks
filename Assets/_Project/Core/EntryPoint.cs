using _Scripts.Field.Cells;
using UnityEngine;
using Zenject;

namespace _Project.Core
{
public class EntryPoint : MonoBehaviour
{
    [Inject] CellCreator _cellCreator;

    void Start( )
    {
        _cellCreator.CreateBoard();
    }

}
}