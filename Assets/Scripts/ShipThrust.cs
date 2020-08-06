using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    // Fields required
    Rigidbody2D Ship;
    Vector2 ThrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    float Radius;
    const float RotateDegreesPerSecond = 90 ;

    // Start is called before the first frame update
    void Start()
    {
        Ship = gameObject.GetComponent<Rigidbody2D>();
        Radius = gameObject.GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Update is called every Frame
    /// </summary>
    private void Update()
    {
        float RotateInput = Input.GetAxis("Rotate");
        if (RotateInput != 0)
        {
            float TotalDegreesToBeRotated = RotateDegreesPerSecond * Time.deltaTime;
            if (RotateInput < 0)
                TotalDegreesToBeRotated *= -1;
            transform.Rotate(Vector3.forward, TotalDegreesToBeRotated);
            float AngleInRadians = transform.eulerAngles.z * Mathf.Deg2Rad;
            ThrustDirection = new Vector2(Mathf.Cos(AngleInRadians), Mathf.Sin(AngleInRadians));
        }
    }

    /// <summary>
    /// Fixed Update Called Every Second
    /// </summary>
    public void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") > 0)
        {
            Ship.AddForce(ThrustDirection * ThrustForce);
        }
    }

    /// <summary>
    /// OnBecameInvisible is called when the associated game object is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 Position = transform.position;
        if (Position.x > ScreenUtils.ScreenRight)
            Position.x = ScreenUtils.ScreenLeft;
        else if (Position.x < ScreenUtils.ScreenLeft)
            Position.x = ScreenUtils.ScreenRight;
        if (Position.y > ScreenUtils.ScreenTop)
            Position.y = ScreenUtils.ScreenBottom;
        else if (Position.y < ScreenUtils.ScreenBottom)
            Position.y = ScreenUtils.ScreenTop;
        transform.position = Position;
    }
}
