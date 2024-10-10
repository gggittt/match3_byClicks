using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;

namespace _Project.Core.Infrastructure.GameStateMachine
{
public interface IGameStateMachine
{
    public void Enter<TState>( )
        where TState : IExcitableState;

    public void Register( IExcitableState state );
}
}