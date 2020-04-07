using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    private void Start() {
        Time.timeScale = 1;
        SoundManager.PlaySound("player-death");
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LevelTwo() {
        SceneManager.LoadScene(2);
    }
}
