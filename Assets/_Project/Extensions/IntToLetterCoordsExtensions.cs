﻿using UnityEngine;

namespace _Project.Extensions
{
//feature from D.Nesteruk
public static class IntToLetterCoordsExtensions
{
    const string EngAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static Vector2Int A( this int self ) //usage look like this: "var coords = 1.A" -> new Vector2Int(1,0)
    {
        int yIndex = EngAlphabet.IndexOf( nameof( A ) );
        return new Vector2Int( self, yIndex );
    }
}
}