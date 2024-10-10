using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core.Buttons
{
public class OpenUrlButton : MonoBehaviour
{
    [SerializeField] string _url;
    [SerializeField] Button _button;

    void Awake( )
    {
        _button.onClick.AddListener( Perform );
    }

    void Perform( )
    {
        Application.OpenURL( _url );
    }

    void OnDestroy( )
    {
        _button.onClick.RemoveAllListeners();
    }
}
}