using UnityEngine;

public class TargetMovement : MonoBehaviour
{

    [SerializeField]
    private Transform topLeft;
    
    [SerializeField]
    private Transform topRight;

    [SerializeField]
    private Transform bottomLeft;
    
    [SerializeField]
    private Transform bottomRight;

    public Vector2 Position => new(transform.position.x, transform.position.y);

    private Vector2 TopLeft => topLeft.position;

    private Vector2 TopRight => topRight.position;

    private Vector2 BottomLeft => bottomLeft.position;

    private Vector2 BottomRight => bottomRight.position;

    public bool TryMoveTarget (Vector2 nextPosition)
    {
        var x = nextPosition.x;
        var y = nextPosition.y;

        var left = TopLeft.x;
        var right = TopRight.x;
        var top = TopRight.y;
        var bottom = BottomLeft.y;

        if (x < left || x > right)
        {
            return false;
        }

        if (y < bottom || y > top)
        {
            return false;
        }

        MoveTarget(nextPosition);
        return true;
    }

    private void MoveTarget(Vector2 nextPosition)
    {
        transform.localPosition = nextPosition;
    }
}