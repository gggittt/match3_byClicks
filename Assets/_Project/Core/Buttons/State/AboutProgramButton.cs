using _Project.Core.Buttons.ButtonContracts;
using _Project.Core.Infrastructure.GameStateMachine;
using _Project.Core.Infrastructure.GameStateMachine.States.LoadScene;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Core.Buttons.State
{
public class AboutProgramButton : ClickListenerButton
{
    // [SerializeField] Button _button; //получаю ош от unity т.к. уже есть в parent class:  The same field name is serialized multiple times in the class or its parent class. This is not supported: Base(MonoBehaviour) _button UnityEditor.InspectorWindow:RedrawFromNative ()

    [Inject] IGameStateMachine _stateMachine;

    protected override void OnCLick( ) =>
        _stateMachine.Enter<AboutProgramState>();

}
public class AboutProgramButtonOld : MonoBehaviour
{
    [SerializeField] Button _button;

    [Inject] IGameStateMachine _stateMachine;

    void Awake( ) =>
        _button.onClick.AddListener( Perform );

    void Perform( ) =>
        _stateMachine.Enter<AboutProgramState>();

    void OnDestroy( ) =>
        _button.onClick.RemoveAllListeners();
}
}