using System;
using UnityEngine;

namespace Exercises
{
    public class Exercise6 : MonoBehaviour
    {
        /*
         * Exercise 6: Loops
            Use a nested for loop to display the following output:
            *
            **
            ***
            ****
            *****
         */

        [SerializeField]
        private int pyramidSize = 5;


        public enum Alignment
        {
            Left, Right
        }

        [SerializeField]
        private Alignment alignment;

        private void Awake()
        {
            
            for (int a = 0; a < 10; a++)
            {
                Debug.Log($"{a}.");
            }
            
            /********************************************/
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Debug.Log($"{i}. -- {j}.");
                }
            }
        }

        private void Start()
        {
            string output = string.Empty;

            for (int i = 0; i < pyramidSize; i++)
            {
                for (int j = 1; j <= i + 1; j++)
                {
                    output += "C";
                }
                output += "\n";
            }

            Debug.Log(output);
        }
    }
}