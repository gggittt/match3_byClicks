using System.Diagnostics.CodeAnalysis;
using _Project._Debug;
using _Project.Core.GameField;
using _Project.Core.GameField.FieldItems;
using _Project.Core.GameField.MatchCheck;
using _Project.Core.Input;
using _Project.Core.Pool;
using _Project.Extensions.Zenject;
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
    [SerializeField] Turns _turns;

    public override void InstallBindings( )
    {
        Container.BindInterfacesAndSelfTo<CellGrid<Cell>>()
           .AsSingle()
           .WithArguments( _gameData.BoardSize );

        Container.BindInterfacesAndSelfTo<ShapeTypes>()
           .AsSingle()
           .WithArguments( _gameData.ShapeTypes );

        Container.BindInterfacesAndSelfTo<ObjectsPool<Item>>()
           .AsSingle()
           .WithArguments( _itemPrefab, _gameData.BoardSize.x * _gameData.BoardSize.y );

        Container.BindInterfacesAndSelfTo<ItemFactory>()
           .AsSingle()
           .WithArguments( _itemShapesDrawer );

        Container.BindInterfacesAndSelfTo<MatchReaper>()
           .AsSingle();

        Container.BindInterfacesAndSelfTo<MatchChecker>()
           .AsSingle();

        Container.BindInterfacesAndSelfTo<SelectionManager>()
           .AsSingle();
        Container.BindInterfacesAndSelfTo<GameOver>()
           .AsSingle();

        Container.BindInterfacesAndSelfAsSingleFromInstance( _gameData );
        Container.BindInterfacesAndSelfAsSingleFromInstance( _cellCreator );
        Container.BindInterfacesAndSelfAsSingleFromInstance( _board );
        Container.BindInterfacesAndSelfAsSingleFromInstance( _turns );
    }
}
}