using TMPro;
using UnityEngine;

namespace _Project.Core
{
public class TurnsView : MonoBehaviour
{
    [SerializeField] TMP_Text _ui;

    public void Set( string text )
    {
        _ui.text = text;
    }

}
}