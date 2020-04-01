using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int score = 0;
    private float timer = 0.0f;
    public Text scoreTextUI;

    private void Update() {
        timer += Time.deltaTime;
        score = (int)(timer % 60);
        scoreTextUI.text = "Score: " + score.ToString();
    }
}
