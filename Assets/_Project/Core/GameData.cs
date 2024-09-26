using UnityEngine;

namespace _Project.Core
{
public class GameData : MonoBehaviour
{
    [SerializeField]
    [Range( 2, 40 )] int BoardWidth, BoardHeight;
    public Vector2Int BoardSize => new Vector2Int( BoardWidth, BoardHeight );
    public ShapeType ShapeTypes;

}
}