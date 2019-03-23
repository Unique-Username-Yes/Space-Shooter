using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerBrain : BaseBrain
{
    public float rangeToFlee = 5.0f;
    public float strageMult = .5f;

    private float rVelocity;
    private Vector2 mVelocity;

    private void Update()
    {
        Vector2 dir = PlayerMovement.pos - rb.position;
        float rAmount = Vector3.Cross(dir, transform.up).z;
        rVelocity = -rAmount * stats.RotationSpeed;

        if (IsRanged)
        {
            float dist = Vector2.Distance(PlayerMovement.pos, rb.position);

            if (dist < rangeToFlee)
            {
                // Flee
                mVelocity = (transform.up * -1.0f) * stats.MovementSpeed;
            }
            else if (dist < stats.Range)
            {
                // Strafe
                mVelocity = (transform.right + (transform.up * 0.01f)) * stats.MovementSpeed * strageMult;

                // Shoot only when in range
                Shoot();
            }
            else
            {
                // Move to target
                mVelocity = transform.up * stats.MovementSpeed;
            }
        }
        else
        {
            mVelocity = transform.up * stats.MovementSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.AddTorque(rVelocity);
        rb.AddForce(mVelocity);
    }

    public override int CalcDmg(bool isBodyDamage)
    {
        if (isBodyDamage)
        {
            return (int)stats.BodyDmg;
        }
        else
        {
            return (int)stats.BulletDmg;
        }
    }
}
