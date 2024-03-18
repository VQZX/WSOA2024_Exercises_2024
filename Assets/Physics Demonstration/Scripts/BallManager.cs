using UnityEngine;

namespace Physics_Demonstration
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField]
        private BallController template;

        [SerializeField]
        private Transform ballSpawnPoint;

        private BallController clone;
        
        public void RespawnBall()
        {
            
        }
    }
}