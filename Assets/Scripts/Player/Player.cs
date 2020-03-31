using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 5f; // player movement speed
    public Rigidbody2D rb;
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealth playerHealth;
    private Vector2 movement;

    // Start is called before the first frame update
    private void Start() {
        currentHealth = maxHealth;
        playerHealth.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update() {
        // get player input
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(20);
        }
    }

    // Handle movement
    private void FixedUpdate() {
        // move player with a constant move speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // reduce the health value of the player when they take damage
    private void TakeDamage(int damage) {
        currentHealth -= damage;
        playerHealth.SetHealth(currentHealth);
    }
}
