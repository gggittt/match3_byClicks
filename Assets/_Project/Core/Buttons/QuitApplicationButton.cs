using _Project.Core.Buttons.ButtonContracts;
using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States;
using Zenject;

namespace _Project.Core.Buttons
{
public class QuitApplicationButton : ClickListenerButton
{
    [Inject] IGameStateMachine _stateMachine;

    protected override void OnCLick( )
    {
        _stateMachine.Enter<QuitApplicationState>();
    }
}
}