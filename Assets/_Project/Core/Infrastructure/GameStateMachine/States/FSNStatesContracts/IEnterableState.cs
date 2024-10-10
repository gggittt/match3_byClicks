namespace _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts
{
public interface IEnterableState : IExcitableState
{
    public void Enter( );
}
}