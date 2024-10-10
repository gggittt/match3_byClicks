using System.Collections;
using UnityEngine;

namespace _Project.Core.Infrastructure
{
public class LoadingCurtain : MonoBehaviour
{
    [SerializeField] CanvasGroup Curtain;

    void Awake( )
    {
        DontDestroyOnLoad( this );
    }

    public void Show( )
    {
        gameObject.SetActive( true );
        Curtain.alpha = 1;
    }

    public void Hide( ) =>
        StartCoroutine( DoFadeIn() );

    IEnumerator DoFadeIn( )
    {
        while ( Curtain.alpha > 0 )
        {
            Curtain.alpha -= 0.03f;
            yield return new WaitForSeconds( 0.03f );
        }

        gameObject.SetActive( false );
    }
}
}