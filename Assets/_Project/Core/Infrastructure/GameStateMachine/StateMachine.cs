﻿using System;
using System.Collections.Generic;
using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using Zenject;

namespace _Project.Core.Infrastructure.GameStateMachine
{
public class StateMachine : IGameStateMachine
{
    readonly Dictionary<Type, IExcitableState> _states = new Dictionary<Type, IExcitableState>(  );

    IExcitableState _currentState;

    // [Inject] void Construct( IEnterableState[] states )
    // {
    //     // _states = new Dictionary<Type, IExcitableState>(  );
    //     foreach ( IEnterableState state in states )
    //     {
    //         Register( state );
    //     }
    // }

    public void Register( IExcitableState state )
    {
        _states.Add( state.GetType(), state );
    }

    public void Enter<TState>( )
        where TState : IExcitableState
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

    void SetNew<TState>( )
        where TState : IExcitableState
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

    TState Get<TState>( )
        where TState : IExcitableState
    {
        return (TState) _states[ typeof( TState ) ];
    }

}
}