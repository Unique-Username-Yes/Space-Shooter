using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    public static Vector2 pos;

    private Rigidbody2D player;
    private Vector2 dir;
    private Vector2 mousePos;
    private Stats stats;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        if (!player)
            Debug.LogError("No player rigid body found in player movement");

        stats = GetComponent<PlayerShip>().stats;
        if (stats==null)
            Debug.LogError("No stats found in player movement");
    }

    private void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = player.position;
    }

    void FixedUpdate()
    {
        // Movement
        player.AddForce(dir.normalized * stats.MovementSpeed);

        // Rotation
        Vector2 rDir = mousePos - player.position;
        player.transform.up = rDir;
    }
}