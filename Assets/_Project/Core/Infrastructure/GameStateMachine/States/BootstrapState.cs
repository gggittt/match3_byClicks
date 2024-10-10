using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure.GameStateMachine.States
{
public class BootstrapState : IEnterableState
{
    // [Inject] GameData _gameData;
    [Inject] IGameStateMachine _gameStateMachine;

    void IEnterableState.Enter( )
    {
        _gameStateMachine.Enter<MainMenuState>();
    }

    void IExcitableState.Exit( ) { }
}
}