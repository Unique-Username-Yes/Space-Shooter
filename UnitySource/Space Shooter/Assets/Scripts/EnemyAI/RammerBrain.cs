using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerBrain : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;

    private Rigidbody2D rb;

    private enum State
    {
        Idle,
        Rotating,
        Moving,
    }

    private State currentState = State.Idle;
    private Vector2 dir;

    public float timeToRotate;
    public float timeToRotateMin = 1.0f;
    public float timeToRotateMax = 3.0f;

    public float currentDistTraveled = 0;
    public float distToTravel;
    public float midAdditionalDist;
    public float maxAdditionalDist;
    public Vector2 lastPos;

    private float rAmount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
            Debug.LogError("Found no rigid body in Boss1");
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dir = (PlayerMovement.pos - rb.position);
        switch (currentState)
        {
            case State.Idle:
                {
                    rb.velocity = Vector2.zero;
                    currentState = State.Rotating;
                    timeToRotate = Random.Range(timeToRotateMin, timeToRotateMax);
                    break;
                }
            case State.Moving:
                {
                    currentDistTraveled += Vector2.Distance(rb.position, lastPos);
                    lastPos = rb.position;
                    rb.velocity = transform.up * movementSpeed;

                    if((distToTravel+Random.Range(midAdditionalDist,maxAdditionalDist))<= currentDistTraveled)
                    {
                        currentState = State.Idle;
                    }
                    // TODO: Switch to idle when fly by player
                    break;
                }
            case State.Rotating:
                {
                    rb.angularVelocity = -rAmount * rotationSpeed;
                    rAmount = Vector3.Cross(dir, transform.up).z;
                    timeToRotate -= Time.deltaTime;
                    break;
                }
        }
        
        if (currentState == State.Rotating && timeToRotate < 0)
        {
            rb.angularVelocity = 0.0f;
            currentState = State.Moving;
            currentDistTraveled = 0;
            distToTravel = Vector2.Distance(rb.position, PlayerMovement.pos);
            lastPos = rb.position;
        }
    }


}
