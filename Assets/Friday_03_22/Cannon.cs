using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private BulletController template;

    [SerializeField]
    private InputAction shoot;


    private void Start()
    {
        shoot.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
        var clone = Instantiate(template, transform.position, Quaternion.identity);
    }

    private void OnEnable()
    {
        shoot.Enable();
    }

    private void OnDisable()
    {
        shoot.Disable();
    }
}
