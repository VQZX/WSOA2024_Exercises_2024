using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exercises
{
    public class FunctionAndArrays : MonoBehaviour
    {
        [SerializeField]
        private List<float> numbers = new List<float>();

        private void Start()
        {
            for (var i = 0; i < numbers.Count - 1; i++)
            {
                var leftElement = numbers[i];
                var rightElement = numbers[i + 1];
                var sum = SumNumbers(leftElement, rightElement);
                Debug.Log(sum);
            } 
        }
        

        private float SumNumbers(float a, float b)
        {
            float sum = a + b;
            return sum;
        }
    }
}