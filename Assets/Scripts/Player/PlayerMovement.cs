using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float maxSpeed;

    private Vector2 _movement;
    private Vector2 _movementDirection => _movement.normalized;

    private void Update()
    {
        if (!joystick) { return; }
        
        _movement = joystick.Direction * maxSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = _movement;
        
        if (_movement == Vector2.zero) { return; }
        
        transform.localEulerAngles = new Vector3(0, 0, 
            Mathf.Atan2(_movementDirection.y, 
                _movementDirection.x) * Mathf.Rad2Deg);
    }
}
