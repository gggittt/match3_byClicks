using _Project.Core.Buttons.ButtonContracts;
using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States.LoadScene;
using Zenject;

namespace _Project.Core.Buttons.State
{
public class NewGameButton : ClickListenerButton
{
    [Inject] IGameStateMachine _stateMachine;

    protected override void OnCLick( )
    {
        _stateMachine.Enter<LoadGameplayState>();
    }
}
}