using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Exercises
{
    public class Exercise5 : MonoBehaviour
    {
        /*
         * Exercise 5: Arrays
            Please do all these questions in the same script:
            1. Make an array of snack names (of your choosing) that contains 5 snack names.
            2. Display element number 3* in the array. *These assume that you start counting from ZERO, not
            ONE
         */

        [SerializeField]
        private List<string> snackNames;

        [SerializeField]
        private int indexToOutput = 3;

        [SerializeField]
        private bool useRandom;

        private void Start()
        {
            

            if (useRandom)
            {
                indexToOutput = Random.Range(0, snackNames.Count);
            }
            
            if (indexToOutput >= snackNames.Count)
            {
                throw new IndexOutOfRangeException(
                    $"The index {indexToOutput} is outside of the range of the array snackNames.\n" +
                    $"The valid ranges is between 0 and {snackNames.Count - 1}");
            }
            
            var element = snackNames[indexToOutput];
            Debug.Log($"The {indexToOutput} element of the array is {element}");
        }
    }
}