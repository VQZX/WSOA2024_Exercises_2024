using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

namespace Physics_Demonstration
{
    public class BallController : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private Rigidbody2D attachedBody;
        public Rigidbody2D AttachedBody => attachedBody;
        
        [SerializeField]
        private Camera mainCamera;

        [SerializeField]
        private float forceMultiplier = 1f;

        [SerializeField]
        private float maxForceMagnitude = 50;

        [SerializeField]
        private float minimumSpeedToStop = 1f;
        
        private Vector3 mouseToBall;
        
        private enum BallState
        {
            Nothing,
            CanInteract,
            Pulling,
            Moving
        }

        private BallState state = BallState.CanInteract;
        
        private float previousMagnitude;
        private float currentMagnitude;

        
        public void OnDrag(PointerEventData eventData)
        {
            if (state != BallState.CanInteract)
            {
                return;
            }

            state = BallState.Pulling;
            Vector3 cursourWorldPosition = mainCamera.ScreenToWorldPoint(eventData.position);
            cursourWorldPosition.z = 0;

            mouseToBall = transform.position - cursourWorldPosition;

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var calculatedForce = mouseToBall * forceMultiplier;
            var magnitude = calculatedForce.magnitude;
            if (magnitude > maxForceMagnitude)
            {
                calculatedForce = mouseToBall.normalized * maxForceMagnitude;
            }
            attachedBody.AddForce(calculatedForce, ForceMode2D.Impulse);
            state = BallState.Moving;
            currentMagnitude = attachedBody.velocity.magnitude;
        }

        private void Start()
        {
            if (attachedBody == null)
            {
                attachedBody = GetComponent<Rigidbody2D>();
            }
        }

        private void Update()
        {
            if (state == BallState.Moving)
            {
                MeasureSpeedToStop();
            }
            
        }

        private void MeasureSpeedToStop()
        {
            if (attachedBody == null)
            {
                return;
            }

            previousMagnitude = currentMagnitude;
            currentMagnitude = attachedBody.velocity.magnitude;
            float acceleration = currentMagnitude - previousMagnitude;
            Debug.Log(acceleration);
            // If the current acceleration is negative, start checking
            if (acceleration < 0)
            {
                Debug.Log($"Current Speed: {attachedBody.velocity.magnitude}");
                var speed = attachedBody.velocity.magnitude;
                if (speed < minimumSpeedToStop)
                {
                    attachedBody.velocity = Vector3.zero;
                    state = BallState.CanInteract;
                }
            }
            
        }
    }
}
