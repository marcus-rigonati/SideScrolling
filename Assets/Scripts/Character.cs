using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character : MonoBehaviour
{
    private const float movementSpeed = 5;
    private Rigidbody2D _rigidbody;
    private bool isGrounded = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void Update()
    {
        var xMovement = Input.GetAxis("Horizontal");
        var yMovement = Input.GetAxis("Vertical");
        var currentVelocity = _rigidbody.velocity;

        // Jump
        var verticalMovement = (yMovement > 0 && isGrounded) ? yMovement * movementSpeed : currentVelocity.y;

        _rigidbody.velocity = new Vector3(xMovement * movementSpeed, verticalMovement);
    }
}
