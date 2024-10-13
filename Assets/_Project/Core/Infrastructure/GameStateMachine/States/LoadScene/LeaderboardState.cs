using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;

namespace _Project.Core.Infrastructure.GameStateMachine.States.LoadScene
{
public class LeaderboardState : LoadSceneState
{
    protected override string SceneName => "Leaderboard";

    public LeaderboardState( SceneLoader sceneLoader ) : base( sceneLoader ) { }
}
}