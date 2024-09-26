using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure
{
public class GameCoreInstaller : MonoInstaller
{
    [SerializeField] GameData _gameData;
    [SerializeField] CellCreator _cellCreator;
    [SerializeField] Item _itemPrefab;
    [SerializeField] ItemShapesDrawer _itemShapesDrawer;

    public override void InstallBindings( )
    {
        CellGrid<Cell> cellGrid = new(_gameData.BoardSize);
        ShapeTypes shapeTypes = new(_gameData.ShapeTypes);

        ObjectsPoolGeneric<Item> objectsPool = new(_itemPrefab, _gameData.BoardSize.x * _gameData.BoardSize.y);
        ItemFactory itemFactory = new(objectsPool, shapeTypes, _itemShapesDrawer);
        Board board = new ( cellGrid, itemFactory );

        Container.BindInstances( _gameData, _cellCreator, cellGrid, objectsPool, itemFactory, board );

    }

}
}