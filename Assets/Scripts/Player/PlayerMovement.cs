using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // player movement speed
    public Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start() {

    }

    // Handle input
    private void Update() {
        // get player input
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    // Handle movement
    private void FixedUpdate() {
        // move player with a constant move speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);      
    }
}
