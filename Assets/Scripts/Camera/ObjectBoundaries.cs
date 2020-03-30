using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBoundaries : MonoBehaviour {
    public Camera MainCamera;
    private Vector2 screenBoundaries;
    private float objectWidth; 
    private float objectHeight; 

    // Start is called before the first frame update
    private void Start() {
        // get coordinates of the screen
        screenBoundaries = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        // get dimensions of the object (player/enemies)
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void LateUpdate() {
        // make sure the object never goes outside screen boundaries
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBoundaries.x * -1 + objectWidth, screenBoundaries.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundaries.y * -1 + objectHeight, screenBoundaries.y - objectHeight);
        transform.position = viewPos;
    }
}
