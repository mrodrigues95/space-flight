using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    public float bulletSpeed = 50.0f;
    public GameObject explosion;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, bulletSpeed);
    }

    // Detect when a player bullet hits an object.
    private void OnTriggerEnter2D(Collider2D other) {
        // when a bullet hits an asteroid, destroy both objects
        if (other.tag == "asteroid") {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Destroy the bullet once it goes off screen
    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
