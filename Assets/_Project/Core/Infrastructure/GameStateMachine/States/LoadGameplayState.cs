using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using Zenject;

namespace _Project.Core.Infrastructure.GameStateMachine.States
{
public class LoadGameplayState : IEnterableState
{
    [Inject] SceneLoader _sceneLoader;
    void IEnterableState.Enter( )
    {
        _sceneLoader.Load( "Gameplay" );
    }

    void IExcitableState.Exit( ) { }
}
}