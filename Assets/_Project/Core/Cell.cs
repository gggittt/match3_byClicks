using UnityEngine;

namespace _Project.Core
{
[RequireComponent( typeof( SpriteRenderer ) )]
public class Cell : MonoBehaviour
{
    public Vector2Int LocalCoord { get; private set; }

    public event System.Action<Cell> Clicked;
    public event System.Action<Cell> Hovered;
    public event System.Action<Cell> UnHovered;


    void OnMouseUpAsButton( )
    {
        Debug.Log( $"<color=cyan> {nameof( OnMouseUpAsButton )} </color>" );

        Clicked?.Invoke( this );
    }

    void OnMouseEnter( )
    {
        Debug.Log( $"<color=cyan> {nameof( OnMouseEnter )} </color>" );

        Hovered?.Invoke( this );
    }

    void OnMouseExit( )
    {
        Debug.Log( $"<color=cyan> {nameof( OnMouseExit )} </color>" );

        UnHovered?.Invoke( this );
    }

    public void Init( Vector2Int coords )
    {
        // _spriteRenderer = GetComponent<SpriteRenderer>();
        LocalCoord = coords;
        name = $"{nameof( Cell )} {LocalCoord} ";
    }

}
}