using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    Vector2 movement;
    public float rememberAngle = 0f;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

        if(movement.x == 0f && movement.y == 0f)
        {
            angle = rememberAngle;
            Debug.Log(angle);
        }

        rigidBody.rotation = angle;
        rememberAngle = angle;
    }
}
