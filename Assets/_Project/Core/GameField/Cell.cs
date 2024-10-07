using _Project.Core.GameField.MatchCheck;
using UnityEngine;

namespace _Project.Core
{
[RequireComponent( typeof( SpriteRenderer ) )]
public class Cell : MonoBehaviour
{
    public Vector2Int LocalCoord { get; private set; }
    public Item Item { get; set; }
    public bool HasItem => Item != null;
    public bool Empty => HasItem == false;

    public event System.Action<Cell> Clicked;

    void OnMouseUpAsButton( )
    {
        Debug.Log( $"<color=cyan> {nameof( OnMouseUpAsButton )} </color>" );

        Clicked?.Invoke( this );
    }

    public void Init( Vector2Int coords )
    {
        // _spriteRenderer = GetComponent<SpriteRenderer>();
        LocalCoord = coords;
        name = $"{nameof( Cell )} {LocalCoord} ";
    }


}
}