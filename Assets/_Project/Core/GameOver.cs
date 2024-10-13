using UnityEngine;

namespace _Project.Core
{
public class GameOver
{
    // _Debug.Csv.HighScoreTable _highScoreTable;
    // Score _score;

    public void Check( int turnsLeft )
    {
        if ( turnsLeft > 0 )
            return;

        // int попадаетВТаблицуРекордов = _score > _highScoreTable.GetLowestScore();
        if ( true )
        {
            OnWin();
        }
        else
        {
            OnLose();
        }

    }

    void OnLose( )
    {
        //show popup -> ok btn -> to menu
        Debug.Log( $"<color=cyan> loser </color>" );

    }

    void OnWin( )
    {
        //сразу на сцену рекордов. выделить строку.
        Debug.Log( $"<color=cyan> winner </color>" );
    }
}
}