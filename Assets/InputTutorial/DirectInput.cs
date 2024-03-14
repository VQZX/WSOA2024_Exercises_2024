using InputTutorial;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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
        Vector2 inputDirection = new Vector2();
        if (currentKeyboard.wKey.isPressed)
        {
            inputDirection += Vector2.up;
        }
        if (currentKeyboard.sKey.isPressed)
        {
            inputDirection += Vector2.down;
        }
        if (currentKeyboard.aKey.isPressed)
        {
            inputDirection += Vector2.left;
        }
        if (currentKeyboard.dKey.isPressed)
        {
            inputDirection += Vector2.right;
        }

        inputDirection = inputDirection.normalized;
        
        
        movementControl.ManageTranslation(inputDirection);
    }
    
    private void ManageOrientation(DeltaControl mouseDelta)
    {
        var delta = new Vector2(mouseDelta.x.value, mouseDelta.y.value);
        movementControl.ManageOrientation(delta);
    }
}
