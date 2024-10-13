using System.Diagnostics.CodeAnalysis;
using Zenject;

namespace _Project.Extensions.Zenject
{
[SuppressMessage( "ReSharper", "InconsistentNaming" )]
public static class DiContainerExtensions
{
    public static void BindInterfacesAndSelfAsSingleTo<T>( this DiContainer Container )
    {
        Container.BindInterfacesAndSelfTo<T>()
           .AsSingle();
    }

    public static void BindInterfacesAndSelfAsSingleFromInstance<T>( this DiContainer Container, T obj )
    {
        Container.BindInterfacesAndSelfTo<T>()
           .FromInstance( obj )
           .AsSingle();
    }
}
}