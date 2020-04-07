using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour {
    public float spawnSpeed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBoundaries;

    // Start is called before the first frame update
    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -spawnSpeed); // move the orb along the Y axis
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    private void Update() {
        // Destroy the orb once it goes off screen
        if (transform.position.y < screenBoundaries.y * 2 * -1) {
            Destroy(this.gameObject);
        }
    }
}
