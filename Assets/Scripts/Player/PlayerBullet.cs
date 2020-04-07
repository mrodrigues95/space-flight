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
        // destroy the enemy object, player bullet and explosion
        if (other.tag == "asteroid") {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(e.gameObject, 5f);
        } else if (other.tag == "enemyShip") {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            SoundManager.PlaySound("enemy-ship-death");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(e.gameObject, 5f);
        }
    }

    // Destroy the bullet once it goes off screen
    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
