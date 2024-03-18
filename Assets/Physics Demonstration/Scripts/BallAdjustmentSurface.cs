using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Physics_Demonstration
{
    public class BallAdjustmentSurface : MonoBehaviour
    {
        private enum Behaviour
        {
            Nothing,
            SpeedUp,
            SlowDown,
            Destroy,
            Teleport
        }

        [SerializeField]
        private BallManager ballManager;
        
        [SerializeField]
        private Behaviour behaviour;

        [SerializeField]
        private float speedUpMultiplier = 2f;

        [SerializeField]
        private float slowDownMultiplier = 2f;

        [SerializeField]
        private float teleportRadius = 2f;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            BallController ball = other.GetComponent<BallController>();
            if (ball == null)
            {
                return;
            }

            switch (behaviour)
            {
                case Behaviour.Nothing:
                    break;
                case Behaviour.SpeedUp:
                    SpeedUp(ball);
                    break;
                case Behaviour.SlowDown:
                    SlowDown(ball);
                    break;
                case Behaviour.Destroy:
                    DestroyBall(ball);
                    break;
                case Behaviour.Teleport:
                    Telelport(ball);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void SpeedUp(BallController ball)
        {
            var velocity = ball.AttachedBody.velocity;
            var magnitude = velocity.magnitude;
            var direction = velocity.normalized;

            var newVelocity = direction * magnitude * speedUpMultiplier;
            ball.AttachedBody.velocity = newVelocity;
        }
        
        private void SlowDown(BallController ball)
        {
            var velocity = ball.AttachedBody.velocity;
            var magnitude = velocity.magnitude;
            var direction = velocity.normalized;

            var newVelocity = direction * magnitude / slowDownMultiplier;
            ball.AttachedBody.velocity = newVelocity;
        }
    
        private void DestroyBall(BallController ball)
        {
            ballManager.RespawnBall();
        }
        
        private void Telelport(BallController ball)
        {
            var randomCirclePoint = Random.insideUnitCircle;
            Vector3 worldPoint = new Vector3(randomCirclePoint.x, randomCirclePoint.y, 0);
            var vectorTo = ball.transform.position + worldPoint * teleportRadius;
            ball.transform.position = vectorTo;
        }
 
    }
}