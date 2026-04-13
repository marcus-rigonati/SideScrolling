using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 20);
    }

    void Update()
    {
        
    }
}
