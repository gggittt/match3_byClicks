
namespace _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts
{
//тогда теряю смысл обоих интерфейсов!
//в IPayloadEnterableState<TPayload> смысл в получении имени следующей сцены
public abstract class State //: IEnterableState
{
    readonly StateMachine _stateMachine;

    protected State( StateMachine stateMachine )
    {
        _stateMachine = stateMachine;
    }

    protected virtual void Enter<TState>( )
        where TState : IExcitableState
    {
        _stateMachine.Enter<TState>();
    }
}

public abstract class LevelSceneState :  SceneState
{
    protected LevelSceneState( SceneLoader sceneLoader ) : base( sceneLoader ) { }
}
//non-Gameplay: playerHomeHubLevel, worldMapLevel, deathScreenLevel,
public abstract class GameplayLevelSceneState :  SceneState
{
    protected GameplayLevelSceneState( SceneLoader sceneLoader ) : base( sceneLoader ) { }
}

public abstract class SceneState : IEnterableState
{
    protected abstract string SceneName { get; }

    readonly SceneLoader _sceneLoader;

    protected SceneState( /*string sceneName,*/ SceneLoader sceneLoader )
    {
        // _sceneName = sceneName;
        _sceneLoader = sceneLoader;
    }

    protected virtual void Enter( ) { }

    void IEnterableState.Enter( )
    {
        Enter();
        LoadScene();
    }

    protected virtual void Exit( ) { } //protected abstract void Exit();

    void IExcitableState.Exit( )
    {
        Exit();
    }

    void LoadScene( )
    {
        _sceneLoader.Load( SceneName );
        // Scene sceneStructNotUnityObj = new();
        // UnityEditor.SceneAsset sceneUnityObj = null;
        // // SceneManager.LoadScene(  ) // = все или string bkb in buildIndex
        // Scene scene = SceneManager.CreateScene("My Scene");
        //
        // float progress = SceneManager.LoadSceneAsync("MyScene").progress;
    }

}
}