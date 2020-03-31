using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int score;
    private float timer = 0.0f;
    public Text scoreTextUI;

    // Start is called before the first frame update
    private void Start() {
        score = 0;
    }

    private void Update() {
        timer += Time.deltaTime;
        score = (int)(timer % 60);
        scoreTextUI.text = "Score: " + score.ToString();
    }
}
