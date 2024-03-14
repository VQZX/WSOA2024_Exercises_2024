using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
        [SerializeField]
        private Rigidbody2D body;

        [SerializeField]
        private FishCorpse template;

        [SerializeField]
        private TimedDelete timedDelete;
        
        public void SetInitialVelocity(Vector2 velocity)
        {
                body.velocity = velocity;
        }

        private void Update()
        {
                if (body.velocity.sqrMagnitude > 0)
                {
                        Debug.Log($"Velocity: {body.velocity}");
                }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
                var targetMovement = other.collider.GetComponent<TargetMovement>();
                if (targetMovement == null)
                {
                        timedDelete.ActivateTime(DestructionSequence);
                        return;
                }
                DestructionSequence();
        }

        private void DestructionSequence()
        {
                Instantiate(template, transform.position, transform.rotation);
                Destroy(gameObject);
        }
}