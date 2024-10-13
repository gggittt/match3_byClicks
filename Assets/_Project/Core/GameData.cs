using System.IO;
using _Project.Core.GameField;
using _Project.Core.GameField.MatchCheck;
using UnityEngine;

namespace _Project.Core
{
public class GameData : MonoBehaviour
{
    [SerializeField]
    [Range( 2, 40 )] int BoardWidth, BoardHeight;
    public Vector2Int BoardSize => new Vector2Int( BoardWidth, BoardHeight );

    [SerializeField] MatchCheckType _matchType = MatchCheckType.AllOrthogonalNeighbours;
    public MatchCheckType MatchType  => _matchType;

    public ShapeType ShapeTypes;


}

}