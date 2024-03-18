using System;
using UnityEngine;

namespace Physics_Demonstration
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 10f;

        [SerializeField]
        private bool isRotating = true;

        private void Update()
        {
            if (isRotating)
            {
                transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * rotationSpeed);
            }
        }
    }
}