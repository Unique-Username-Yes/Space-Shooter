using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBrain : MonoBehaviour
{
    private Vector2 target = Vector2.zero;

    public float speed;
    public float rSpeed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("No ArrowBrain body found");

        // Movement
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = PlayerMovement.pos - rb.position;
        dir.Normalize();

        float rAmount = Vector3.Cross(dir, transform.up).z;

        // Rotation
        rb.angularVelocity = -rAmount * rSpeed;

        rb.velocity = transform.up * speed;
    }
}
