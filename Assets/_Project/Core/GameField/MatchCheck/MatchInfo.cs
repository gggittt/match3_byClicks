using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Core.GameField.MatchCheck
{
public class MatchInfo
{
    public HashSet<Vector2Int> AllSuitableItems { get; }
    public bool HasMatch => AllSuitableItems.Any();
    public int ItemsCount => AllSuitableItems.Count;

    public MatchInfo( Vector2Int center )
    {
        AllSuitableItems = new() { center };
    }

    public void Add( HashSet<Vector2Int> coordinatesRange )
    {
        AllSuitableItems.UnionWith( coordinatesRange );
    }

    public override string ToString( )
    {
        if ( HasMatch )
        {
            return "<color=green> match info: </color>" + string.Join( ", ", AllSuitableItems );
        }

        return "<color=pink> Combo not found </color>";
    }

}
}