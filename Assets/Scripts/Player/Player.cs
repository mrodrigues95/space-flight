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
    public GameObject gameOverUI;
    public GameObject bulletPrefab;
    public Transform bulletPoint;
    private Vector2 movement;
    private Scene currentScene;

    // Start is called before the first frame update
    private void Start() {
        currentScene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        playerHealth.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update() {
        if (Input.GetKeyDown("space")) {
            ShootBullet();
        }

        // stop the game when the player dies
        if (currentHealth <= 0) {
            gameOverUI.SetActive(true);
            // TODO: Find a better way to manage game state and remove this.
            Time.timeScale = 0f;
        }
    }

    // Handle movement
    private void FixedUpdate() {
        // get player input
        movement.x = Input.GetAxisRaw("Horizontal");

        // enable vertical movement if the player is on level 2
        if (currentScene.name == "LevelTwo") {
            movement.y = Input.GetAxisRaw("Vertical");
        }

        // move player with a constant move speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Detect player collision with enemy objects.
    private void OnTriggerEnter2D(Collider2D other) {
        // load explosion prefab
        GameObject e = Instantiate(explosion) as GameObject;
        // load the explosion animation at the current players position
        e.transform.position = transform.position;
        // play the asteroid collision sound
        SoundManager.PlaySound("asteroid-collision");
        // remove asteroid from the scene
        Destroy(other.gameObject);
        // reduce player health
        playerHealth.TakeDamage(20, this);
    }

    public void ShootBullet() {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        SoundManager.PlaySound("player-shoot-bullet");
        b.transform.position = bulletPoint.position;
    }
}
