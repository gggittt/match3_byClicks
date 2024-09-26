using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Core
{
[RequireComponent( typeof( SpriteRenderer ) )]
public class ItemView : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }

    void Awake( )
    {
        InitRequired();
    }

    void OnValidate( )
    {
        InitRequired();
    }

    void InitRequired( )
    {
        if ( !SpriteRenderer )
            SpriteRenderer = GetComponent<SpriteRenderer>();
    }

}
}