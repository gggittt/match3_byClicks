using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using Zenject;

namespace _Project.Core.Infrastructure.GameStateMachine.States
{
public class BootstrapState : IEnterableState
{
    [Inject] IGameStateMachine _gameStateMachine;

    void IEnterableState.Enter( )
    {
        _gameStateMachine.Enter<MainMenuState>();
    }

    void IExcitableState.Exit( ) { }
}
}