namespace _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts
{
public interface IEnterableState : IExcitableState
{
    public void Enter( );
}
public interface IPayloadEnterableState : IExcitableState
{
    public void Enter<TPayload>( TPayload payload );
}
}