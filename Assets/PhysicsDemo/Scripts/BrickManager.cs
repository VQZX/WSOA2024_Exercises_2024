using System.Collections.Generic;
using PhysicsDemo;
using UnityEngine;
using UnityEngine.Serialization;

public class BrickManager : MonoBehaviour
{
    [SerializeField]
    private Brick brick;

    [SerializeField]
    private bool generateOnAwake = true;

    [SerializeField]
    private int rows, columns;

    [FormerlySerializedAs("brickSize")]
    [SerializeField]
    private float brickWidth = 0.215f;

    [SerializeField]
    private float brickHeight = 0.1025f;

    [SerializeField]
    private List<Brick> bricks = new List<Brick>();
    
    private void Awake()
    {
        if (!generateOnAwake)
        {
            return;
        }
        BuildBrickWall();
    }

    private void BuildBrickWall()
    {
        var initialPosition = transform.position;
        for (int i = 0; i < columns; i++)
        {
            if (i % 2 == 1)
            {
                initialPosition += Vector3.right * brickWidth * 0.5f;
            }
            else
            {
                initialPosition -= Vector3.right * brickWidth * 0.5f;
            }
            
            for (int j = 0; j < rows; j++)
            {
                var position = initialPosition + new Vector3(brickWidth,0,0) * j;
                var clone = Instantiate(brick, transform);
                clone.transform.position = position;
                bricks.Add(clone);
                
                var duplicatePosition = position;
                duplicatePosition.z -= 0.25f;
                var duplicateClone = Instantiate(brick, transform);
                duplicateClone.transform.position = duplicatePosition;
                
                bricks.Add(duplicateClone);
            }

            initialPosition += Vector3.up * brickHeight;
            Debug.Log(initialPosition);
        }
    }
}
