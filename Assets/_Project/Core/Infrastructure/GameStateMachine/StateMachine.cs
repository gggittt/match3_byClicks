using System;
using System.Collections.Generic;
using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using Zenject;

namespace _Project.Core.Infrastructure.GameStateMachine
{
public class StateMachine : IGameStateMachine
{
    readonly Dictionary<Type, IExcitableState> _states = new();

    IExcitableState _currentState;

    public void Register( IExcitableState state )
    {
        _states.Add( state.GetType(), state );
    }

    public void Enter<TState>( ) where TState : IExcitableState
    {
        TryExitPrevious();

        SetNew<TState>();

        TryEnter();
    }

    void TryExitPrevious( )
    {
        if ( _currentState is IExcitableState excitable )
        {
            excitable.Exit();
        }
    }

    void SetNew<TState>( ) where TState : IExcitableState
    {
        TState newState = Get<TState>();
        _currentState = newState;
    }

    void TryEnter( )
    {
        if ( _currentState is IEnterableState enterable )
        {
            enterable.Enter();
        }
    }

    TState Get<TState>( ) where TState : IExcitableState
    {
        TState excitableState;
        try
        {
            excitableState = (TState) _states[ typeof( TState ) ];

        } catch (Exception e)
        {
            UnityEngine.Debug.Log( $"<color=green> Probably launched from wrong scene. Need to start from Bootstrap </color>" );

            throw e;
        }

        return excitableState;
    }

}
}