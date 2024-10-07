using UnityEngine;

namespace _Project.Core
{
public class ItemShapesDrawer : MonoBehaviour
{
    [SerializeField] SerializableDictionary<ShapeType, Sprite> _spritesForNotSingleShapes; //fixme rename

    public void SetSprite( ShapeType shapeType, SpriteRenderer rendererToSpriteDraw )
    {
        if ( _spritesForNotSingleShapes.TryGetValue( shapeType, out Sprite sprite ) )
        {
            rendererToSpriteDraw.sprite = sprite;
        }
    }
}
}