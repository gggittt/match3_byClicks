using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Core.Pool
{
public class ObjectsPool<T>
    where T : MonoBehaviour, IReleasable
{
    readonly Stack<T> _objects;
    readonly T _prefab;

    public ObjectsPool( T prefab, int prewarmObjectsAmount = 0 )
    {
        _prefab = prefab;
        _objects = new Stack<T>();

        for ( int i = 0; i < prewarmObjectsAmount; i++ )
        {
            T obj = Create( );
            obj.gameObject.SetActive( false );
        }
    }

    public T Get( )
    {
        T obj = _objects.FirstOrDefault( x => !x.isActiveAndEnabled );

        if ( obj == null )
            obj = Create();

        obj.gameObject.SetActive( true );
        return obj;
    }

    public void Release( T obj )
    {
        obj.OnRelease();
    }

    T Create( )
    {
        T obj = Object.Instantiate( _prefab );
        _objects.Push( obj );
        return obj;
    }
}

}
