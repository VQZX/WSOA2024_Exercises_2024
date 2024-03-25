using System;
using System.Collections;
using System.Collections.Generic;
using Physics_Demonstration;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    [SerializeField]
    private Vector2 initialVelocity;

    private void Start()
    {
        body.velocity = initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        if (target == null)
        {
            return;
        }
        PrefabUtilities.DoNothing();
        Destroy(gameObject);
    }
}



