using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    //public GameManager gameManager;

    // set players max health value to 100
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f); // set health bar color to green
    }

    // everytime the player takes damage, reduce the visual slider
    public void SetHealth(int health) {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // reduce the health value of the player when they take damage
    public void TakeDamage(int damage, Player player) {
        player.currentHealth -= damage;
        SetHealth(player.currentHealth);
    }
}
