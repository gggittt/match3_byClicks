using UnityEngine;

namespace _Project.Core.GameField
{
public class Direction
{

    const int UpIsDown = -1;

    public static readonly Direction Up = new Direction( 0, 1 ) * UpIsDown ;
    public static readonly Direction Right = new Direction( 1, 0 );
    public static readonly Direction Down = new Direction( 0, - 1 )  * UpIsDown;
    public static readonly Direction Left = new Direction( - 1, 0 );

    public static readonly Direction UpRight = Up + Right;
    public static readonly Direction DownRight = Down + Right;
    public static readonly Direction DownLeft = Down + Left;
    public static readonly Direction UpLeft = Up + Left;

    public static readonly Direction[] Orthogonal = { Up, Right, Down, Left };
    public static readonly Direction[] Diagonals = { UpRight, DownRight, DownLeft, UpLeft };

    public static readonly Direction[] Vertical = { Up, Down };
    public static readonly Direction[] Horizontal = { Left, Right };
    public static readonly Direction[] DiagonalFromNorthWest = { UpLeft, DownRight };
    public static readonly Direction[] DiagonalFromNorthEast = { UpRight, DownLeft };


    public static readonly Direction[][] AllAxes = { Vertical, Horizontal, DiagonalFromNorthWest, DiagonalFromNorthEast, };

    public static readonly Direction[,] AllAxes2 = { { Up, Down }, { Right, Left, }, { UpLeft, DownRight }, { UpRight, DownLeft } };

    public static readonly Direction[,] OrthogonalAxes = { { Up, Down }, { Right, Left, } };
    public static readonly Direction[,] DiagonalsAxes = { { UpLeft, DownRight }, { UpRight, DownLeft } };


    public int X { get; } //ColumnDelta
    public int Y { get; } //RowDelta

    public Direction( int x, int y )
    {
        X = x;
        Y = y;
    }


    public Direction( Vector2Int dir ) : this( dir.x, dir.y ) { }

    public static Direction operator +( Direction dir1, Direction dir2 ) =>
        new Direction( dir1.X + dir2.X, dir2.Y + dir1.Y );

    public static Direction operator *( int factor, Direction dir ) =>
        new Direction( factor * dir.X, factor * dir.Y );

    public static Direction operator *( Direction dir, int factor ) =>
        factor * dir;

    public static Vector2Int operator +( Vector2Int pos, Direction dir ) =>
        new Vector2Int( pos.x + dir.X, pos.y + dir.Y );

    public static implicit operator Vector2Int( Direction self )
        => new Vector2Int( self.X, self.Y );

    public override string ToString( )
    {
        string result = "";
        if ( this == Up )
            result = nameof( Up );
        else if ( this == Right )
            result = nameof( Right );
        else if ( this == Down )
            result = nameof( Down );
        else if ( this == Left )
            result = nameof( Left );
        else if ( this == UpRight )
            result = nameof( UpRight );
        else if ( this == DownRight )
            result = nameof( DownRight );
        else if ( this == DownLeft )
            result = nameof( DownLeft );
        else if ( this == UpLeft )
            result = nameof( UpLeft );

        return result;
    }
}
}