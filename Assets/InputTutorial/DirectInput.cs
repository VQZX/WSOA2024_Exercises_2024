using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using InputTutorial;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class DirectInput : MonoBehaviour
{

    [SerializeField]
    private MovementControl movementControl;
    
    [SerializeField]
    private float mouseDeadZone = 0.05f;
    
    private Keyboard currentKeyboard = Keyboard.current;
    private Mouse currentMouse = Mouse.current;
    
    private void ManageTranslation()
    {
        movementControl.ManageTranslation(currentKeyboard);
        var motion = Vector3.zero;
        if (currentKeyboard.wKey.isPressed)
        {
            motion += Vector3.forward;
        }

        if (currentKeyboard.sKey.isPressed)
        {
            motion += Vector3.back;
        }

        if (currentKeyboard.aKey.isPressed)
        {
            motion += Vector3.left;
        }

        if (currentKeyboard.dKey.isPressed)
        {
            motion += Vector3.right;
        }

        motion = motion.normalized;

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
    
    private void ManageOrientation()
    {
        var mouseDelta = currentMouse.delta;
        if (mouseDelta.magnitude < mouseDeadZone)
        {
            return;
        }
        movementControl.ManageOrientation(mouseDelta);
    }
}
