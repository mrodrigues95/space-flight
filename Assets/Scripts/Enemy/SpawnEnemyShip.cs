using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyShip : MonoBehaviour {
    public GameObject enemyShipPrefab;
    public GameObject enemyBulletPrefab;
    public float respawnTime;
    private bool isEnemyShipAlive = false;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(EnemyShipWave());
        InvokeRepeating("EnemyShootBullet", 4.0f, 1.0f);
    }

    // Spawn a new enemy ship.
    private void SpawnShip() {
        // bottom left most point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // bottom right most point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // add an enemy ship to the scene
        GameObject enemyShip = Instantiate(enemyShipPrefab) as GameObject;
        // spawn the enemy at the top left point of the screen
        enemyShip.transform.position = new Vector2(min.x + 2, max.y + -2);
        // shoot a bullet
        EnemyShootBullet();
    }

    // Call "SpawnShip()" on the respawnTime interval.
    private IEnumerator EnemyShipWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            SpawnShip();
        }
    }

    private void EnemyShootBullet() {
        isEnemyShipAlive = GameObject.FindWithTag("enemyShip");
        // fire a bullet from the enemy ships current position
        if (isEnemyShipAlive) {
            GameObject enemyShipBullet = Instantiate(enemyBulletPrefab) as GameObject;
            enemyShipBullet.transform.position = GameObject.FindWithTag("enemyShip").transform.position;
        }
    }
}
