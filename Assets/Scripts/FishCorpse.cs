using System;
using UnityEngine;

public class FishCorpse : MonoBehaviour
{
    [SerializeField]
    private float dissapearTime = 4f;

    private float currentTime = 0;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (currentTime >= dissapearTime)
        {
            Destroy(gameObject);
            return;
        }

        currentTime += Time.deltaTime;
        var normalisedScale = currentTime / dissapearTime;
        var nextScale = Vector3.Lerp(initialScale, Vector3.zero, normalisedScale);
        transform.localScale = nextScale;
    }
}