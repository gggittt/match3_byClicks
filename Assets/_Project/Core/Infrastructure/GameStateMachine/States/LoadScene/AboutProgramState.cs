using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;

namespace _Project.Core.Infrastructure.GameStateMachine.States.LoadScene
{
public class AboutProgramState : LoadSceneState
{
    protected override string SceneName => "AboutProgram";

    public AboutProgramState( SceneLoader sceneLoader ) : base( sceneLoader ) { }
}
}