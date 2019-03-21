using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    public static Vector2 pos;

    //[HideInInspector]
    public float speed;
    private float smoothT = .15f;

    private Rigidbody2D player;
    private Vector2 dir;
    private Vector2 vel;
    private Vector2 mousePos;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        if (!player)
            Debug.LogError("No player rigid body found in player movement");
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
        player.AddForce(dir.normalized * speed);
        pos = player.position;

        // Rotation
        Vector2 rDir = mousePos - player.position;
        player.transform.up = rDir;
    }
}