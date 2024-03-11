using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputTutorial
{
    public class EmbeddedActionInput : MonoBehaviour
    {
        [SerializeField]
        private MovementControl movementControl;
        
        [SerializeField]
        private InputAction move;

        [SerializeField]
        private InputAction turn;

        private Vector2 moveDelta;
        
        private void Awake()
        {
            move.performed += MovementAction;
            turn.performed += TurnAction;
        }

        private void Update()
        {
            if (moveDelta.sqrMagnitude > 0)
            {
                movementControl.ManageTranslation(moveDelta);
            }

            if (move.WasReleasedThisFrame())
            {
                moveDelta = Vector2.zero;
            }
        }

        private void MovementAction(InputAction.CallbackContext context)
        {
            var inputData = context.ReadValue<Vector2>();
            moveDelta = inputData;
            movementControl.ManageTranslation(inputData);
        }

        private void TurnAction(InputAction.CallbackContext context)
        {
            var inputData = context.ReadValue<Vector2>();
            movementControl.ManageOrientation(inputData);
        }

        private void OnEnable()
        {
            move.Enable();
            turn.Enable();
        }

        private void OnDisable()
        {
            move.Disable();
            turn.Disable();
        }
    }
}