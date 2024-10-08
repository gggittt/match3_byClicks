﻿using _Project.Core.Infrastructure.GameStateMachine;
using Zenject;

namespace _Project.Core.Infrastructure.ZenjectInstallers
{
public class GlobalInstaller : MonoInstaller, ICoroutineRunner
{
    public override void InstallBindings( )
    {
        Container.Bind<ICoroutineRunner>()
           .To<GlobalInstaller>()
           .FromInstance( this )
           .AsSingle();

        Container
           .BindInterfacesAndSelfTo<StateMachine>()
           .AsSingle();

        Container
           .BindInterfacesAndSelfTo<SceneLoader>()
           .AsSingle();

    }
}

public static class ZenjectDiContainerExtensions
{
    public static void BindInterfacesAndSelfAsSingleTo<T>( this DiContainer Container )
    {
        Container.BindInterfacesAndSelfTo<T>()
           .AsSingle();
    }
}
}