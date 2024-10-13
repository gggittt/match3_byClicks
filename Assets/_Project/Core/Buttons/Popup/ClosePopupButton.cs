using _Project.Extensions.UnityTypes;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core.Buttons.Popup
{
public class ClosePopupButton : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] RectTransform _popupWindow;

    void Awake( )
    {
        _button.onClick.AddListener( Perform );
    }

    void Perform( )
    {
        _popupWindow.DisableGameObject();
    }

    void OnDestroy( )
    {
        _button.onClick.RemoveAllListeners();
    }
}
}