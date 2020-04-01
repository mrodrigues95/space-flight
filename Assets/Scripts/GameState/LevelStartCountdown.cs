using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartCountdown : MonoBehaviour {
    public Text countdownTextUI;

    private void Start() {
        StartCoroutine(CountdownToStart());
    }

    // Display a short count down at each level start
    private IEnumerator CountdownToStart() {
        countdownTextUI.text = "Avoid the asteroids for as long as possible!";
        yield return new WaitForSeconds(2f);
        countdownTextUI.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownTextUI.gameObject.SetActive(false);
    }
}
