using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    // Load the first level
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    // Exit the game
    public void QuitGame() {
        Debug.Log("Game was exited!");
        Application.Quit();
    }
}
