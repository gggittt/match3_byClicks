using UnityEngine;
using UnityEngine.UI;

namespace _Project.Core.Buttons.ButtonContracts
{
[RequireComponent( typeof( Button ) )]
public abstract class ClickListenerButton : MonoBehaviour
{
    [SerializeField] Button _button;
    protected Button Button => _button;

    void OnValidate( ) =>
        _button = GetComponent<Button>();

    void OnEnable( ) =>
        _button.onClick.AddListener( OnCLick );

    void OnDisable( ) =>
        _button.onClick.RemoveListener( OnCLick );


    protected abstract void OnCLick( );
}
}