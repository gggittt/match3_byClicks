using UnityEngine;

namespace _Project.Core
{
public class Turns : MonoBehaviour
{
    [SerializeField] TurnsView _view;
    [SerializeField] int _value;

    void Awake( )
    {
        UpdateUi();
    }

    public void SpendOne( ) => ChangeValueBy( - 1 );

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
        UpdateUi();
    }

    void UpdateUi( )
    {
        _view.Set( _value.ToString() );
    }
}
}