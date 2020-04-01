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
        countdownTextUI.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownTextUI.gameObject.SetActive(false);
    }
}
