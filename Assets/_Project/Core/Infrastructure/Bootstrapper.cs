using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States;
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
        //проблемы с циклической зависимостью. StateMachine должна знать о всех состоянихя (для Dictionary<Type, State> _states), и в State должна быть ссылка на StateMachine.
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