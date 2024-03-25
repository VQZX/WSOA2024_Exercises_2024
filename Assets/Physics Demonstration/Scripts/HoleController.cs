using System;
using System.Collections;
using System.Collections.Generic;
using Physics_Demonstration;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ballController = other.GetComponent<BallController>();
        if (ballController == null)
        {
            return;
        }
        Destroy(ballController.gameObject);
    }
}
