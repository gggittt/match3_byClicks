using _Project.Core.Infrastructure.GameStateMachine.States.FSNStatesContracts;
using UnityEditor;
using UnityEngine;

namespace _Project.Core.Infrastructure.GameStateMachine.States
{
public class QuitApplicationState : IEnterableState
{
    void IEnterableState.Enter( )
    {
        //save, ...
        ( (IExcitableState) this ).Exit();
    }

    void IExcitableState.Exit( )
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
}