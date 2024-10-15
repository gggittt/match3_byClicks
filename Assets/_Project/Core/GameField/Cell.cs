using _Project.Core.GameField.FieldItems;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project.Core.GameField
{
[RequireComponent( typeof( SpriteRenderer ) )]
public class Cell : MonoBehaviour, IPointerClickHandler
{
    public Vector2Int LocalCoord { get; private set; }
    public Item Item { get; set; }
    public bool HasItem => Item != null;
    public bool Empty => HasItem == false;

    public event System.Action<Cell> Clicked;

    public void Init( Vector2Int coords )
    {
        // _spriteRenderer = GetComponent<SpriteRenderer>();
        LocalCoord = coords;
        name = $"{nameof( Cell )} {LocalCoord} ";
    }

    public void OnPointerClick( PointerEventData eventData )
    {
        Debug.Log( $"<color=cyan> {nameof( OnPointerClick )} </color>" );

        Clicked?.Invoke( this );
    }
}
}