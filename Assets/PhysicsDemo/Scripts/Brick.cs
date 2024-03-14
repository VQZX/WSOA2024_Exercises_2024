using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PhysicsDemo
{
    public class Brick : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer meshRenderer;

        [SerializeField]
        private Rigidbody attachedBody;

        private float delayTime = 2f;
        private float currentTime;
        
        private void Awake()
        {
            var color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
            
            meshRenderer.material.SetColor("_Color", color);
            attachedBody = GetComponent<Rigidbody>();
            attachedBody.Sleep();
        }

        private void Update()
        {
            if (currentTime < delayTime)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                attachedBody.constraints = RigidbodyConstraints.None;
            }
        }
    }
}