using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameManagerState {
        Menu,
        Gameplay,
        GameOver
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    private void Start() {
        GMState = GameManagerState.Menu;
        UpdateGameManagerState();
    }

    // Keep track of the current game state
    private void UpdateGameManagerState() {
        switch (GMState) {
            case GameManagerState.GameOver:
                Time.timeScale = 0f;
                break;
        }
    }

    // Set the game state and update it
    public void SetGameManagerState(GameManagerState state) {
        GMState = state;
        UpdateGameManagerState();
    }
}
