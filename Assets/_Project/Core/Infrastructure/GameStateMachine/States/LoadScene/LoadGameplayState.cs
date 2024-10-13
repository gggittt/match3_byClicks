using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;

namespace _Project.Core.Infrastructure.GameStateMachine.States.LoadScene
{
public class LoadGameplayState : LoadSceneState
{
    protected override string SceneName  => "Gameplay" ;
    public LoadGameplayState( SceneLoader sceneLoader ) : base( sceneLoader ) { }
}
}