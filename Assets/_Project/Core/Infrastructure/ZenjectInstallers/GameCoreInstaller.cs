using _Project.Core.GameField;
using _Project.Core.GameField.FieldItems;
using _Project.Core.GameField.MatchCheck;
using _Project.Core.Input;
using _Project.Core.Pool;
using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure.ZenjectInstallers
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

        ObjectsPool<Item> objectsPool = new(_itemPrefab, _gameData.BoardSize.x * _gameData.BoardSize.y);
        ItemFactory itemFactory = new(objectsPool, shapeTypes, _itemShapesDrawer);
        MatchReaper matchReaper = new(cellGrid, _gameData, objectsPool);
        MatchChecker matchChecker = new(_board.IsNeighborSameShape, matchReaper, _gameData);
        SelectionManager selectionManager = new(_board);

        Container.BindInstances( _gameData, _cellCreator, cellGrid, objectsPool, itemFactory, _board, matchReaper, matchChecker );

        Container
           .BindInterfacesAndSelfTo<SelectionManager>()
           .FromInstance( selectionManager )
           .AsSingle()
            ;

    }
}
}