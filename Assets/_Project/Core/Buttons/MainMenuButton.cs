using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core.Menus
{
public class MainMenuButton : MonoBehaviour
{
    [SerializeField] Button _button;

    [Inject] IGameStateMachine _stateMachine;

    void Awake( )
    {
        _button.onClick.AddListener( Perform );
    }

    void Perform( )
    {
        _stateMachine.Enter<MainMenuState>();
    }

    void OnDestroy( )
    {
        _button.onClick.RemoveAllListeners();
    }
}
}