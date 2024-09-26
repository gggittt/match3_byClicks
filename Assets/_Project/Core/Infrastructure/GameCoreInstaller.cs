using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure
{
public class GameCoreInstaller : MonoInstaller
{
    [SerializeField] GameData _gameData;
    [SerializeField] CellCreator _cellCreator;

    public override void InstallBindings( )
    {
        CellGrid<Cell> cellGrid = new(_gameData.BoardSize);


        Container.BindInstances( _gameData, _cellCreator, cellGrid );

    }

}
}