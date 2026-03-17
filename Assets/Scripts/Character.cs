using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Character : MonoBehaviour
{
    private const float movementSpeed = 5;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider;
    private bool isGrounded = false;
    private GameObject currentGround;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var halfColliderSize = _boxCollider.size.y / 2;
        var isBeneathCharacter = (transform.position.y - halfColliderSize) > collision.GetContact(0).point.y;

        if (isBeneathCharacter && !isGrounded)
        {
            isGrounded = true;
            currentGround = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(currentGround))
        {
            isGrounded = false;
            currentGround = null;
        }
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
