using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareManager : MonoBehaviour
{
    [SerializeField]
    private SquareController template;

    [SerializeField]
    private int amountOfClones = 10;

    [SerializeField]
    private float positionMultiplier = 3;

    private List<SquareController> squares = new List<SquareController>();
    private float initialX;

    private void Start()
    {
        initialX = transform.position.x;
        for (int i = 0; i < amountOfClones; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * positionMultiplier;
            var position = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);
            
            //var clone = Instantiate(template, position, Quaternion.identity);
            var clone = Instantiate(template, transform);
            clone.transform.localPosition = position;
            squares.Add(clone);
        }
    }

    private void Update()
    {
        var deltaX = 10 * Mathf.Sin(Time.time * 2);
        var nextX = initialX + deltaX;
        transform.position = new Vector3(nextX, transform.position.y, 0);
    }
}
