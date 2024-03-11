using UnityEngine;

public class BasicCameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;


    private float currentTime = 0;
    
    
    private enum Transitioning
    {
        Nothing,
        CanUpdatePosition,
        UpdatingPosition
    }

    private Transitioning transitionState = Transitioning.CanUpdatePosition;
    

    private void Update()
    {
        if (target == null)
        {
            return;
        }
        
        // Look at the target
        transform.LookAt(target);
        SelectNextPosition();

    }
    
    private void SelectNextPosition()
    {
        // Orbit around the player
        /*
         * Rotation in 3D around the y-component to get the correct forward orientation
         * Because they y-component goes upwards in Unity,
         * We only have to worry about adjust the x and z values.
         * As such we only rotate around the y-component in 3D as such
         * per vector-matrix calculation
         * x = motionVector.x * cos(theta) + 0 + motionVector.z * sin(theta)
         * y = 0 + motionVector.y + 0
         * z = motionVector.x * (-sin(theta)) + 0 + motionVector.z * cos(theta)
         *
         * Where theta is the targets y-rotation in the euler angles
         */
        var yRotation = target.localRotation.eulerAngles.y * Mathf.Deg2Rad;
        var xPrime = offset.x * Mathf.Cos(yRotation) + offset.z * Mathf.Sin(yRotation);
        var zPrime = -offset.x * Mathf.Sin(yRotation) + offset.z * Mathf.Cos(yRotation);

        var rotatedOffsetVector = new Vector3(xPrime, offset.y, zPrime);
        transform.localPosition = target.position + rotatedOffsetVector;
    }
}
