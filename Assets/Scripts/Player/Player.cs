using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float moveSpeed = 5f; // player movement speed
    public Rigidbody2D rb;
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerHealth playerHealth;
    public GameObject explosion;
    private Vector2 movement;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    private void Start() {
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        playerHealth.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update() {
        // get player input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // stop the game when the player dies
        if (currentHealth <= 0) {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    // Handle movement
    private void FixedUpdate() {
        // move player with a constant move speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Detect player collision with asteroids
    private void OnTriggerEnter2D(Collider2D other) {
        // load explosion prefab
        GameObject e = Instantiate(explosion) as GameObject;
        // load the explosion animation at the current players position
        e.transform.position = transform.position;
        // remove asteroid from the scene
        Destroy(other.gameObject);
        // reduce player health
        playerHealth.TakeDamage(20, this);
    }
}
