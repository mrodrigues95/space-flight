using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public float spawnSpeed = 10.0f;
    public float movementSpeed = 2.5f;
    private Rigidbody2D rb;
    private Vector2 screenBoundaries;

    // Start is called before the first frame update
    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(movementSpeed, 0);
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Destroy the enemy ship once it goes off screen
    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
