using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static AudioClip asteroidCollisionSound;
    public static AudioClip asteroidDestroyedSound;
    public static AudioClip playerdeathSound;
    public static AudioClip playerBulletSound;
    public static AudioClip enemyShipDeathSound;
    private static AudioSource audioSource;

    // Start is called before the first frame update
    private void Start() {
        playerBulletSound = Resources.Load<AudioClip>("Sounds/Player/laser_04");
        asteroidCollisionSound = Resources.Load<AudioClip>("Sounds/Enemy/explosion_02");
        asteroidDestroyedSound = Resources.Load<AudioClip>("Sounds/Enemy/asteroidDestroyed");
        playerdeathSound = Resources.Load<AudioClip>("Sounds/game_over_21");
        enemyShipDeathSound = Resources.Load<AudioClip>("Sounds/Enemy/enemyship_death");
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
    }

    // Determine which sound to play according to what is happening to the player.
    public static void PlaySound(string clip) {
        switch(clip) {
            case "asteroid-collision":
                audioSource.PlayOneShot(asteroidCollisionSound);
                break;
            case "asteroid-destroyed":
                audioSource.PlayOneShot(asteroidDestroyedSound);
                break;
            case "player-death":
                audioSource.PlayOneShot(playerdeathSound);
                break;
            case "player-shoot-bullet":
                audioSource.PlayOneShot(playerBulletSound);
                break;
            case "enemy-ship-death":
                audioSource.PlayOneShot(enemyShipDeathSound);
                break;
        }
    }
}
