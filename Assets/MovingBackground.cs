using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {
    public float speed = 1f; // background speed
    public float clamps;
    [HideInInspector] public Vector3 startPosition;

    // Start is called before the first frame update
    void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        float newPosition = Mathf.Repeat(Time.time * speed, clamps);
        transform.position = startPosition + Vector3.up * newPosition;
    }
}
