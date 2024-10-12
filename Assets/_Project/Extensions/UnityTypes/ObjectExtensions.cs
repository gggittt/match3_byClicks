using System.IO;
using UnityEngine;

namespace _Project.Extensions.UnityTypes
{
public static class ObjectExtensions
{
    public static void DestroyItself( this Object self ) => Object.Destroy( self );

    public static string GetFullPath( this Object self ) =>
        Path.GetFullPath( self.name );
}
}