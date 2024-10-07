using DG.Tweening;
using UnityEngine;

namespace _Project.Core.GameField.FieldItems
{
public class ItemMovement : MonoBehaviour
{
    [SerializeField] float _moveDuration = .4f;


    public void Move( Vector3 target )
    {
        transform.DOMove( target, duration: _moveDuration );

    }
}
}