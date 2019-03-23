using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammerBrain : BaseBrain
{
    public float midAdditionalDist;
    public float maxAdditionalDist;
    

    public float timeToRotate;
    public float timeToRotateMin = 1.0f;
    public float timeToRotateMax = 3.0f;

    private Vector2 lastPos;
    private float currentDistTraveled = 0;
    private float distToTravel;

    private float rVelocity;
    private Vector2 mVelocity;

    private enum State
    {
        Idle,
        Rotating,
        Moving,
    }

    private State currentState = State.Idle;

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                {
                    mVelocity = Vector2.zero;
                    currentState = State.Rotating;
                    timeToRotate = Random.Range(timeToRotateMin, timeToRotateMax);
                    break;
                }
            case State.Moving:
                {
                    currentDistTraveled += Vector2.Distance(rb.position, lastPos);
                    lastPos = rb.position;
                    mVelocity = transform.up * stats.MovementSpeed;

                    if((distToTravel+Random.Range(midAdditionalDist,maxAdditionalDist))<= currentDistTraveled)
                    {
                        currentState = State.Idle;
                    }
                    // TODO: Switch to idle when fly by player
                    break;
                }
            case State.Rotating:
                {
                    Vector2 dir = (PlayerMovement.pos - rb.position);
                    float rAmount = Vector3.Cross(dir, transform.up).z;
                    rVelocity = -rAmount * stats.RotationSpeed;
                    timeToRotate -= Time.deltaTime;
                    break;
                }
        }
        
        if (currentState == State.Rotating && timeToRotate < 0)
        {
            rVelocity = 0.0f;
            currentState = State.Moving;
            currentDistTraveled = 0;
            distToTravel = Vector2.Distance(rb.position, PlayerMovement.pos);
            lastPos = rb.position;
        }
    }

    private void FixedUpdate()
    {
        rb.AddTorque(rVelocity);
        rb.AddForce(mVelocity);
    }

    public override int CalcDmg(bool isBodyDamage)
    {
        throw new System.NotImplementedException();
    }
}
