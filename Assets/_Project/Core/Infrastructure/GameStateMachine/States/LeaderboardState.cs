using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using Zenject;

namespace _Project.Core.Infrastructure.GameStateMachine.States
{
public class LeaderboardState : IEnterableState
{
    [Inject] SceneLoader _sceneLoader;
    void IEnterableState.Enter( )
    {
        _sceneLoader.Load( "Leaderboard" );
    }

    void IExcitableState.Exit( ) { }
}
}