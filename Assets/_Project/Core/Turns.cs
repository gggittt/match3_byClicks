using System;
using UnityEngine;

namespace _Project.Core
{
public class Turns : MonoBehaviour
{
    [SerializeField] TurnsView _view;
    [SerializeField] int _value = 3;

    public event Action<int> Changed;
    public event Action<int> Spend;

    void Awake( )
    {
        UpdateUi();
    }

    public void SpendOne( )
    {
        ChangeValueBy( - 1 );
        Spend?.Invoke( _value );
    }

    public void Add( int i = 1 )
    {
        if ( i < 1 )
        {
            return;
        }

        ChangeValueBy( i );
    }

    void ChangeValueBy( int i )
    {
        _value += i;
        // Changed?.Invoke( _value );
        UpdateUi();
    }

    void UpdateUi( )
    {
        _view.Set( _value.ToString() );
    }
}
}