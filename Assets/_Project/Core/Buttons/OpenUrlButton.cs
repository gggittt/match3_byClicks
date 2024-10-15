using _Project.Core.Buttons.ButtonContracts;
using UnityEngine;

namespace _Project.Core.Buttons
{
public class OpenUrlButton : ClickListenerButton
{
    [SerializeField] string _url;

    protected override void OnCLick( )
    {
        Application.OpenURL( _url );
    }
}
}