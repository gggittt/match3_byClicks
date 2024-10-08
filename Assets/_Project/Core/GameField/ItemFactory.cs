﻿using _Project.Core.GameField.FieldItems;
using _Project.Core.Pool;

namespace _Project.Core.GameField
{
public class ItemFactory
{
    readonly ObjectsPool<Item> _objectsPool;
    readonly ShapeTypes _shapeTypes;
    readonly ItemShapesDrawer _itemShapesDrawer;

    public ItemFactory( ObjectsPool<Item> objectsPool, ShapeTypes shapeTypes, ItemShapesDrawer itemShapesDrawer )
    {
        _objectsPool = objectsPool;
        _shapeTypes = shapeTypes;
        _itemShapesDrawer = itemShapesDrawer;
    }

    public Item CreateItem( Cell cell )
    {
        Item item = _objectsPool.Get();
        ShapeType randomShape = _shapeTypes.RandomAllowedToSpawnType;
        item.Init( randomShape, cell.transform.position );
        item.View.PlayAppearAnimation();

        _itemShapesDrawer.SetSprite( randomShape, item.View.SpriteRenderer );

        PutItemToCell( cell, item );

        return item;
    }

    void PutItemToCell( Cell cell, Item item )
    {
        cell.Item = item;
        item.transform.parent = cell.transform;
    }
}
}