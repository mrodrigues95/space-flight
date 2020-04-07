using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroids : MonoBehaviour {
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Scene currentScene;

    // Start is called before the first frame update
    private void Start() {
        currentScene = SceneManager.GetActiveScene();
        InvokeRepeating("IncreaseAsteroidSpawnTimer", 5.0f, 3.0f);
        StartCoroutine(AsteroidWave());
    }

    private void SpawnAsteroid() {
        // bottom left most point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // bottom right most point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // add a asteroid to the scene
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        // change the size of the asteroids if the player is currently on level 2
        if (currentScene.name == "LevelTwo") {
            a.transform.localScale = new Vector2(4, 4);
        }
        a.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
	}

    private IEnumerator AsteroidWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            SpawnAsteroid();
        }
    }

    // Increase the rate of which asteroids will spawn over time.
    private void IncreaseAsteroidSpawnTimer() {
        Debug.Log(respawnTime);
        if (respawnTime > 0.10) {
            respawnTime -= 0.10f;
        }
    }
}
