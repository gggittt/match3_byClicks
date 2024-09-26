using _Project.Core.GameField.MatchCheck;
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
    [SerializeField] Board _board;

    public override void InstallBindings( )
    {
        CellGrid<Cell> cellGrid = new(_gameData.BoardSize);
        ShapeTypes shapeTypes = new(_gameData.ShapeTypes);

        ObjectsPoolGeneric<Item> objectsPool = new(_itemPrefab, _gameData.BoardSize.x * _gameData.BoardSize.y);
        ItemFactory itemFactory = new(objectsPool, shapeTypes, _itemShapesDrawer);
        MatchReaper matchReaper = new MatchReaper( cellGrid, _gameData, objectsPool );
        MatchChecker matchChecker = new MatchChecker( _board.IsNeighborSameShape, matchReaper );
        SelectionManager selectionManager = new SelectionManager( _board );

        Container.BindInstances( _gameData, _cellCreator, cellGrid, objectsPool, itemFactory, _board, matchReaper, matchChecker, selectionManager );

    }

}
}