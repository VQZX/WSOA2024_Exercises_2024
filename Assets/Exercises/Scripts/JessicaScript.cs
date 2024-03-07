using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JessicaScript : MonoBehaviour
{
    [SerializeField]    
    private float length = 2.6f;

    [SerializeField]
    private float width = 3.8f;

    private void Start()
    {
        float area = length * width;
        Debug.Log(area);
    }

}
