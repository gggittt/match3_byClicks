using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States;
using UnityEngine;
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

        //❌
        // Container.BindInterfacesAndSelfTo<BootstrapState>().FromInstance( new BootstrapState() ).AsSingle().WhenInjectedInto<StateMachine>();;
        // Container.BindInterfacesAndSelfTo<MainMenuState>().FromInstance( new MainMenuState() ).AsSingle().WhenInjectedInto<StateMachine>();;
        // Container.BindInterfacesAndSelfTo<LoadGameplayState>().FromInstance( new LoadGameplayState() ).AsSingle().WhenInjectedInto<StateMachine>();;

        //❌
        // Container.BindInterfacesAndSelfTo<BootstrapState>().FromInstance( new BootstrapState() ).AsSingle();
        // Container.BindInterfacesAndSelfTo<MainMenuState>().FromInstance( new MainMenuState() ).AsSingle();
        // Container.BindInterfacesAndSelfTo<LoadGameplayState>().FromInstance( new LoadGameplayState() ).AsSingle();
        //❌
        // Container.BindInstance( new BootstrapState() ).AsSingle();
        // Container.BindInstance( new MainMenuState() ).AsSingle();
        // Container.BindInstance( new LoadGameplayState() ).AsSingle();

        //❌ ZenjectException: Unable to resolve 'IGameStateMachine' while building object with type 'BootstrapState'. Object graph:BootstrapState = проблемы т.к. в каждом State есть ссылка на FSN, и FSN должна получить ссылки на все states
        // Container.Instantiate<BootstrapState>();
        // Container.Instantiate<MainMenuState>();
        // Container.Instantiate<LoadGameplayState>();

        // Container.BindInterfacesAndSelfTo<StateMachine>().WhenInjectedIntoInstance(  )

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