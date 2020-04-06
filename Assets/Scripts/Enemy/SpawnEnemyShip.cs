using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyShip : MonoBehaviour {
    public GameObject enemyShipPrefab;
    public float respawnTime;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(EnemyShipWave());
    }

    // Spawn a new enemy ship.
    private void SpawnShip() {
        // bottom left most point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // bottom right most point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // add a asteroid to the scene
        GameObject enemyShip = Instantiate(enemyShipPrefab) as GameObject;
        enemyShip.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        Debug.Log("New enemy ship spawned.");
    }

    // Call "SpawnShip()" on the respawnTime interval.
    private IEnumerator EnemyShipWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            SpawnShip();
        }
    }
}
