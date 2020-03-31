using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour {
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(AsteroidWave());
    }

    private void SpawnAsteroid() {
        // bottom left most point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // bottom right most point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // add asteroid to the scene
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
	}

    private IEnumerator AsteroidWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            SpawnAsteroid();
        }
    }
}
