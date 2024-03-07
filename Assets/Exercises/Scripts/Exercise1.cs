using UnityEngine;

namespace Exercises
{
    public class Exercise1 : MonoBehaviour
    {
        /*
         * Exercise 1: Steps to Coding
            Write an algorithm to display the area of a rectangle. Remember that Area = Length x Width.
         */
        [SerializeField]
        private float length;

        private float Length;

        [SerializeField]
        private float width = 1;
        

        
        private void Start()
        {
            
            float area = length * width;
            string output = $"The area is: {area}";
            
            Debug.Log(area);
        }

        private void Update()
        {
            
        }

    }
}
