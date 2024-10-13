using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States;
using _Project.Core.Infrastructure.GameStateMachine.States.LoadScene;
using UnityEngine;
using Zenject;

namespace _Project.Core.Infrastructure
{
public class Bootstrapper : MonoBehaviour
{
    [Inject] IGameStateMachine _gameStateMachine;
    [Inject] DiContainer _diContainer; //IInstantiator

    void Start( )
    {
        _gameStateMachine.Register( _diContainer.Instantiate<BootstrapState>() );
        _gameStateMachine.Register( _diContainer.Instantiate<MainMenuState>() );
        _gameStateMachine.Register( _diContainer.Instantiate<LoadGameplayState>() );
        _gameStateMachine.Register( _diContainer.Instantiate<AboutProgramState>() );
        _gameStateMachine.Register( _diContainer.Instantiate<QuitApplicationState>() );

        _gameStateMachine.Enter<BootstrapState>();

        DontDestroyOnLoad( this );
    }
}
}