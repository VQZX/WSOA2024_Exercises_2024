using UnityEngine;
using UnityRandom = UnityEngine.Random;


namespace SecondCodingExercises.MultidimensionalArrays
{
    public class Map : MonoBehaviour
    {
        private float[,] map = new float[3, 3];

        private void Start()
        {
            
            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = UnityRandom.Range(-100, 100);
                    var element = map[i, j];
                    Debug.Log($"{i}.{j}: {element}");
                }
            }
        }
    }
}