using InputTutorial;
using UnityEngine;

public class PhysicalMovement : MovementControl
{
    [SerializeField]
    private Rigidbody attachedBody;

    [SerializeField]
    private float movementForce = 100f;

    public override void ManageTranslation(Vector2 normalisedPosition)
    {
        var calculatedForce = new Vector3(normalisedPosition.x, 0, normalisedPosition.y);
        calculatedForce *= movementForce;
        attachedBody.AddForce(calculatedForce);
    }
}
