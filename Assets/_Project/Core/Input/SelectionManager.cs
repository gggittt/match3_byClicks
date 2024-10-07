using UnityEngine;

namespace _Project.Core.Input
{
class SelectionManager
{
    readonly Board _board;
    float _previousClickTime;
    float _pauseBetweenClicks = 0.7f;

    public SelectionManager( Board board ) =>
        _board = board;

    public void OnCellClick( Cell cell )
    {
        if ( IsInputBlocked() )
        {
            return;
        }

        _board.HandleClick( cell );
    }

    bool IsInputBlocked( )
    {
        float elapsed = Time.time - _previousClickTime;
        Debug.Log( $"<color=cyan> Time.time: {Time.time} </color>" );

        if ( elapsed < _pauseBetweenClicks )
        {
            Debug.Log( $"<color=orange> инпут ещё в блоке по таймауту кликов. с прошлого клика прошло:</color> {elapsed} " );
            return true;
        }

        _previousClickTime = Time.time;

        return false;
    }

}
}