using UnityEngine;

namespace Exercises
{
    public class Exercise3 : MonoBehaviour
    {
        /*
         * Please do all these questions in the same script:
            1. Write a program that generates a random integer between 1 and 10.
            2. Find out whether that integer is less than five – and store the result in a bool.
            3. Make a string. If your bool from the last question is TRUE, store the words “The number is less
                than five” inside that string. If the bool is false, store the words “The number is greater than or
                equal to five” inside the string.
            4. Display the string inside the console.
            5. Write code to display whether your random number is even or odd.
         */

        private void Start()
        {
            int randomInteger = Random.Range(1, 10);
            bool result = randomInteger < 5;
            string outputString = $"The number is {(result ? "less than five" : "more than, or equal to five")}";
            Debug.Log(outputString);

            bool even = randomInteger % 2 == 0;
            outputString = "";
            if (even)
            {
                outputString = "even";
            }
            else
            {
                outputString = "odd";
            }
            Debug.Log(outputString);
            
        }
    }
}