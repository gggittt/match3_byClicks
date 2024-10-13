namespace _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts
{
public abstract class LoadSceneState : IEnterableState
{
    protected abstract string SceneName { get; }

    readonly SceneLoader _sceneLoader;

    protected LoadSceneState( SceneLoader sceneLoader ) =>
        _sceneLoader = sceneLoader;

    protected virtual void Enter( ) { } //rename to OnBeforeLoad ?

    void IEnterableState.Enter( )
    {
        Enter();
        LoadScene();
        // OnAfterLoad();
    }

    protected virtual void Exit( ) { }

    void IExcitableState.Exit( ) =>
        Exit();

    void LoadScene( ) =>
        _sceneLoader.Load( SceneName );
}
}