using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using InputTutorial;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
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

    private void Update()
    {
        if (CanTranslate())
        {
            ManageTranslation();
        }

        if (currentMouse.delta.magnitude > mouseDeadZone)
        {
            ManageOrientation(currentMouse.delta);
        }
    }

    private bool CanTranslate()
    {
        var output = currentKeyboard.wKey.isPressed ||
                     currentKeyboard.sKey.isPressed ||
                     currentKeyboard.aKey.isPressed ||
                     currentKeyboard.dKey.isPressed;
        return output;
    }

    private void ManageTranslation()
    {
        movementControl.ManageTranslation(currentKeyboard);
    }
    
    private void ManageOrientation(DeltaControl mouseDelta)
    {
        movementControl.ManageOrientation(mouseDelta);
    }
}
