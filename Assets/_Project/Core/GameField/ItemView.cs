using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Project.Core
{
[RequireComponent( typeof( SpriteRenderer ) )]
public class ItemView : MonoBehaviour
{
    [SerializeField] float _disappearAnimationDuration = 0.3f;

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

    public void PlayDestroyAnimation( TweenCallback onComplete )
    {
        Sequence sequence = DOTween.Sequence()
           .SetEase( Ease.InOutSine );

        transform.DOScale( 0, _disappearAnimationDuration );

        sequence.OnComplete( onComplete );
    }

}
}