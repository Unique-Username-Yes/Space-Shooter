using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speed = 5f;
    public float smoothT = .1f;
    public Rigidbody2D player;

    Vector2 dir = Vector2.zero;
    Vector2 vel = Vector2.zero;
    Vector2 mousePos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        Vector2 dirVelocity = dir * speed;
        player.velocity = Vector2.SmoothDamp(player.velocity, dirVelocity, ref vel, smoothT);

        // Rotation
        Vector2 rDir = mousePos - player.position;
        //float angle = Mathf.Atan2(rDir.y, rDir.x) * Mathf.Rad2Deg - 90f;
        //player.rotation = angle;

        player.transform.up = rDir;
    }
}
