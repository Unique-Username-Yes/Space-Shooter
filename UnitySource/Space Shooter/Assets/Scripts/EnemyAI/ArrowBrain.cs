using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBrain : MonoBehaviour
{

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

    }
}
