using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnOrbs : MonoBehaviour {
    public GameObject orbPrefab;
    public float respawnTime = 3.0f;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(OrbWave());
    }

    private void SpawnOrb() {
        // bottom left most point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // bottom right most point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // add a asteroid to the scene
        GameObject a = Instantiate(orbPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }

    private IEnumerator OrbWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            SpawnOrb();
        }
    }
}
