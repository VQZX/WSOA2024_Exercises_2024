using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace InputTutorial
{
    public class MovementControl : MonoBehaviour
    {
        [SerializeField]
        private float speed = 7f;

        [SerializeField]
        private float angularSpeed = 10f;
        
        public void ManageTranslation(Vector2 normalisedPosition)
        {
            var motion = Vector3.zero;
            motion.x = normalisedPosition.x;
            motion.z = normalisedPosition.y;

            var motionVector = motion * speed * Time.deltaTime;
            
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

            var yRotation = transform.localRotation.eulerAngles.y * Mathf.Deg2Rad;
            var xPrime = motionVector.x * Mathf.Cos(yRotation) + motionVector.z * Mathf.Sin(yRotation);
            var zPrime = -motionVector.x * Mathf.Sin(yRotation) + motionVector.z * Mathf.Cos(yRotation);

            var rotatedMotionVector = new Vector3(xPrime, motionVector.y, zPrime);
            
            transform.position += rotatedMotionVector * speed * Time.deltaTime;
        }
    
        public void ManageOrientation(Vector2 delta)
        {
            var playerRotation = angularSpeed * delta.x * Time.deltaTime;
            transform.localRotation *= Quaternion.Euler(0, playerRotation, 0);
        }
    }
}