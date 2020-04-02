using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static AudioClip asteroidCollisionSound;
    public static AudioClip playerdeathSound;
    private static AudioSource audioSource;

    // Start is called before the first frame update
    private void Start() {
        asteroidCollisionSound = Resources.Load<AudioClip>("Sounds/Enemy/explosion_02");
        playerdeathSound = Resources.Load<AudioClip>("Sounds/game_over_21");
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }

    // Determine which sound to play according to what is happening to the player.
    public static void PlaySound(string clip) {
        switch(clip) {
            case "asteroid-collision":
                audioSource.PlayOneShot(asteroidCollisionSound);
                break;
            case "player-death":
                audioSource.PlayOneShot(playerdeathSound);
                break;
        }
    }
}
