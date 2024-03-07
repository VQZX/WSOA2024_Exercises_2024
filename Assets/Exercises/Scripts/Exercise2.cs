using System;
using UnityEngine;

namespace Exercises
{
    public class Exercise2 : MonoBehaviour
    {
        /*
         * Exercise 2: Making Your First Program
            Write a program that displays your name and your favourite game when the program first runs. Write a
            program that, for every frame, displays the words “This message displays itself every frame”.
         */
        
        [SerializeField]
        private string inputName = "John Doe";

        [SerializeField]
        private string game = "Tetris";
        
        private void Start()
        {
            Debug.Log("Hello World.");
            var outputString = $"My name is {inputName}, and my favourite game is {game}";
            Debug.Log(outputString);
        }

        private void Update()
        {
            Debug.Log("This message displays every frame");
        }
    }
}