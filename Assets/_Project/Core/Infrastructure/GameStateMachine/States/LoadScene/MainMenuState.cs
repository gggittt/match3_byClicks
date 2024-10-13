using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;

namespace _Project.Core.Infrastructure.GameStateMachine.States
{
public class MainMenuState : LoadSceneState
{
    protected override string SceneName => "MainMenu";

    public MainMenuState( SceneLoader sceneLoader ) : base( sceneLoader ) { }
}
}