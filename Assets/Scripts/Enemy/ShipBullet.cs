using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour {
    public float bulletSpeed = 50.0f;
    public GameObject explosion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -bulletSpeed);
    }

    // Detect when an enemy bullet hits the player.
    private void OnTriggerEnter2D(Collider2D other) {
        // when a bullet hits an asteroid, destroy both objects
        if (other.tag == "Player") {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);
            Destroy(e.gameObject, 5f);
        }
    }

    // Destroy the bullet once it goes off screen
    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
