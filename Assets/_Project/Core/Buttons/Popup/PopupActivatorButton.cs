using _Project.Core.Buttons.ButtonContracts;
using _Project.Extensions.UnityTypes;
using UnityEngine;

namespace _Project.Core.Buttons.Popup
{
public class PopupActivatorButton : ClickListenerButton
{
    [SerializeField] RectTransform _popupWindow;
    [SerializeField] EnableState _enableState = EnableState.Disabled;

    protected override void OnCLick( )
    {
        if ( _enableState == EnableState.Disabled )
        {
            _popupWindow.DisableGameObject();
        }
        else if ( _enableState == EnableState.Enabled )
        {
            _popupWindow.EnableGameObject();
        }
    }
}
}