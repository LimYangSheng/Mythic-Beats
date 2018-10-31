﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTutorial : MonoBehaviour {

    public int health;

    private bool isDead;
    private AudioSource enemyDamagedSound;

    // Use this for initialization
    void Start() {
        isDead = false;
        enemyDamagedSound = GetComponent<AudioSource>();
    }

    public void takeDamage(int dmg) {
        handleDamageTaken(dmg);
    }

    private void handleDamageTaken(int dmg) {
        if (health - dmg >= 0) {
            health -= dmg;
            enemyDamagedSound.Play();
        }
        else {
            health = 0;
        }
        EventManager.TriggerEvent("UpdateEnemyHealth");
        checkAndSetIfDead();
    }

    private void checkAndSetIfDead() {
        if (health <= 0) {
            isDead = true;
        }
    }

    public bool getIsDead() {
        return isDead;
    }
}
