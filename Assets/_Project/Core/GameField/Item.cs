using UnityEngine;

namespace _Project.Core
{
[RequireComponent( typeof( ItemView ) )]
public class Item : MonoBehaviour, IReleasable
{
    [field: SerializeField] public ShapeType Shape { get; private set; }
    public bool CanBeMatchedWith( Item other ) => other && HasSameFlag( other );
    public bool HasSameFlag( Item other ) => Shape.ContainsAny( other.Shape );

    public bool IsSameShape( Item other ) => other && Shape == other.Shape;

    public Cell ParentCell { get; private set; }

    public ItemView View { get; private set; }
    // public ItemMovement Movement { get; private set; }

    public void Init( ShapeType shapeType, Vector3 position )
    {
        InitRequired();
        Shape = shapeType;

        transform.position = position;

        name = GetName();
    }

    public void SetParentAndMoveToParent( Cell parent )
    {
        ParentCell = parent;
        transform.SetParent( parent.transform );
        transform.localPosition = Vector3.zero;
    }

    void OnValidate( )
    {
        InitRequired();
    }

    void InitRequired( )
    {
        if ( !View )
            View = GetComponent<ItemView>();
        // if ( !Movement )
        //     Movement = GetComponent<ItemMovement>();
    }

    public override string ToString( ) => GetName();
    string GetName( ) => $"{GetType().Name}, {Shape}";

    void IReleasable.OnRelease( )
    {
        View.PlayDestroyAnimation( OnAnimationFinish );

    }

    void OnAnimationFinish( )
    {
        gameObject.SetActive( false );
        transform.parent = null;
    }

}
}