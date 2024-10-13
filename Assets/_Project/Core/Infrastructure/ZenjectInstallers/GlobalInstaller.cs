using _Project.Core.Infrastructure.GameStateMachine;
using Zenject;

namespace _Project.Core.Infrastructure.ZenjectInstallers
{
//ProjectContext
public class GlobalInstaller : MonoInstaller, ICoroutineRunner
{
    public override void InstallBindings( )
    {
        Container.Bind<ICoroutineRunner>()
           .To<GlobalInstaller>()
           .FromInstance( this )
           .AsSingle();

        Container.BindInterfacesAndSelfTo<StateMachine>()
           .AsSingle();

        Container.BindInterfacesAndSelfTo<SceneLoader>()
           .AsSingle();
    }
}
}