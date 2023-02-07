using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering2 : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 5.0f;

    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);
        rigidbody2d.velocity = direction * speed;

        if (direction.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigidbody2d.rotation = Mathf.LerpAngle(rigidbody2d.rotation, angle, turnSpeed * Time.deltaTime);
        }
    }
}