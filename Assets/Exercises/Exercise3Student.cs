using UnityEngine;

namespace Exercises
{
    public class Exercise3Student : MonoBehaviour
    {
        private int random;
        private bool isLessThanFive;
        private void Start()
        {
            random = Random.Range(1, 10);
            isLessThanFive = random < 5;

            if (isLessThanFive) 
            {
                var outputLessThanFive = "The number is less than five.";
                Debug.Log(outputLessThanFive);
            }   
            else
            {
                var outputIsMoreThanFiveOrFive = "The number is greater than or equal to five.";
                Debug.Log(outputIsMoreThanFiveOrFive);
            }
        }
    }
}