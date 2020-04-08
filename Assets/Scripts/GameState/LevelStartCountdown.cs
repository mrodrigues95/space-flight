using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelStartCountdown : MonoBehaviour {
    public Text countdownTextUI;
    private Scene currentScene;

    private void Start() {
        currentScene = SceneManager.GetActiveScene();
        StartCoroutine(CountdownToStart());
    }

    // Display a short count down at each level start
    private IEnumerator CountdownToStart() {
        if (currentScene.name == "LevelOne") {
            countdownTextUI.text = "Avoid the asteroids for as long as possible!";
        } else if (currentScene.name == "LevelTwo") {
            countdownTextUI.text = "Destroy as many enemies as you can!\nUse your left mouse to shoot.";
            yield return new WaitForSeconds(3f);
            countdownTextUI.text = "You can now move up and down with the w and s keys.";
        }
        yield return new WaitForSeconds(3f);
        countdownTextUI.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownTextUI.gameObject.SetActive(false);
    }
}
