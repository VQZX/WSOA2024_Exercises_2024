using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareController : MonoBehaviour
{
    [SerializeField]
    private float frequencyOfColorChange;

    [SerializeField]
    private SpriteRenderer spriteRender;

    [SerializeField]
    private float movementSpeed = 5f;

    [SerializeField]
    private float radiusOfMotion = 1;
    
    private float currentTime;
    private Vector3 initialLocalPosition;


    private void Start()
    {
        radiusOfMotion = Random.Range(3, 56);
        movementSpeed = Random.Range(1, 12);
        initialLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        ChangeColorByTimer();

        HandleMovement();
    }

    private void HandleMovement()
    {
        float x = initialLocalPosition.x + radiusOfMotion * Mathf.Cos(Time.time * movementSpeed);
        float y = initialLocalPosition.y + radiusOfMotion * Mathf.Sin(Time.time * movementSpeed);

        transform.localPosition = new Vector3(x, y);

    }

    private void ChangeColorByTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime < frequencyOfColorChange)
        {
            return;
        }
        
        // Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue)
        Color color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
        spriteRender.color = color;
        currentTime = 0;
    }
}
