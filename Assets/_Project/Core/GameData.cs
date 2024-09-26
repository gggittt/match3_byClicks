using _Scripts.PersistentProgress;
using UnityEngine;

namespace _Project.Core
{
public class GameData : MonoBehaviour
{
    [SerializeField]
    [Range( 2, 40 )] int BoardWidth, BoardHeight;
    public Vector2Int BoardSize => new Vector2Int( BoardWidth, BoardHeight );

    [SerializeField] Turns _turns;
    public ShapeType ShapeTypes;

    public void AddBonusTurns( int amount )
    {
        _turns.Add( amount );
    }
}

}