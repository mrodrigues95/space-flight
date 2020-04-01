using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingBackground : MonoBehaviour {
    public float speed = 1f; // background speed
    public float clamps;
    [HideInInspector] public Vector3 startPosition;
    private float timer = 20.0f;

    // Start is called before the first frame update
    private void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update() {
        float newPosition = Mathf.Repeat(Time.time * speed, clamps);
        transform.position = startPosition + Vector3.down * newPosition;
    }

    private void FixedUpdate() {
        // set the scrolling speed of the background to 60.0
        if (speed < 60.0) {
            timer += Time.deltaTime;
            speed = timer;
        }
    }
}
