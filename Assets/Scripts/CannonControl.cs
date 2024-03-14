using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    [SerializeField]
    private SliderController sliderController;
    
    [SerializeField]
    private Projectile fishTemplate;

    [SerializeField]
    private Transform instantiationPoint;

    private List<Projectile> projectiles = new List<Projectile>();
    
    public void Shoot()
    {
        var aimPosition = target.position;
        var time  = sliderController.TimeInSeconds;
        
        var initialVelocity = CalculateInitialVelocity(transform.position, aimPosition, Physics2D.gravity, time);
        var clone = Instantiate(fishTemplate, transform.position, Quaternion.identity);
        projectiles.Add(clone);
        clone.SetInitialVelocity(initialVelocity);
    }

    private static Vector2 CalculateInitialVelocity(Vector2 start, Vector2 end, Vector2 acceleration, float time)
    {
        // Delete this
        // Error: Missing calculation
        // 𝑠 = 𝑢𝑡 + 0.5 𝑎𝑡^2
        // displacement = velocity * time + 0.5 * acceleration * time * time
        var displacement = end - start;
        // displacement - 0.5 * acceleration * time * time = velocity * time
        // (displacement/time) - 0.5 * acceleration * time = velocity
        // velocity = (displacement/time) - 0.5 * acceleration * time;
        var velocity = (displacement / time) - 0.5f * acceleration * time;
        return velocity;
    }
}
