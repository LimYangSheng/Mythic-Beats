﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    private enum TutorialStage {
        MovementWithoutBeat,
        MovementWithBeat,
        TogglingToAttack,
        NormalAttack,
        ComboAttack
    };

    private TutorialStage currentStage;
    [HideInInspector] public bool isTextShowing;
    [HideInInspector] public bool isMovementEnabled;
    [HideInInspector] public bool isBeatEnabled;
    [HideInInspector] public bool isAttackTogglingEnabled;
    [HideInInspector] public bool isComboEnabled;
    [HideInInspector] public bool isAttackTogglingObjectiveCompleted;
    [HideInInspector] public bool isComboObjectiveCompleted;
    private bool[] directionChecklist; // in order of up, down, left, right
    private bool[] attackDirectionChecklist; // in order of up, down, left, right

    private GameObject enemy;
    

    void Awake() {
        enemy = GameObject.Find("Enemy");

        setupMovementWithoutBeatStage();
    }

    void Start() {
        enemy.SetActive(false);    
    }

    void Update() {
        switch (currentStage) {
            case TutorialStage.MovementWithoutBeat:
                if (checkDirectionChecklist()) {
                    setupMovementWithBeatStage();
                }
                break;
            case TutorialStage.MovementWithBeat:
                if (checkDirectionChecklist()) {
                    //setupTogglingToAttackStage();
                    setupNormalAttackStage();
                }
                break;
            case TutorialStage.TogglingToAttack:
                if (isAttackTogglingObjectiveCompleted) {
                    setupNormalAttackStage();
                }
                break;
            case TutorialStage.NormalAttack:
                if (checkAttackDirectionChecklist()) {
                    setupComboAttackStage();
                }
                break;
            case TutorialStage.ComboAttack:
                if (isComboObjectiveCompleted) {
                    transitToMainGame();
                }
                break;
        }    
    }

    private bool checkDirectionChecklist() {
        foreach (bool val in directionChecklist) {
            if (val == false) {
                return false;
            }
        }
        return true;
    }

    private bool checkAttackDirectionChecklist() {
        foreach (bool val in attackDirectionChecklist) {
            if (val == false) {
                return false;
            }
        }
        return true;
    }

    private void transitToMainGame() {
        // do nothing for now
        Debug.Log("Transiting to main game");
    }

    public void checkDirectionChecklist(int direction) {
        directionChecklist[direction] = true;
    }

    public void checkAttackDirectionChecklist(int direction) {
        attackDirectionChecklist[direction] = true;
    }

    private void setupMovementWithoutBeatStage() {
        currentStage = TutorialStage.MovementWithoutBeat;
        isTextShowing = true;
        isMovementEnabled = true;
        isBeatEnabled = false;
        isAttackTogglingEnabled = false;
        isComboEnabled = false;
        directionChecklist = new bool[4];
        attackDirectionChecklist = new bool[4];
        isAttackTogglingObjectiveCompleted = false;
        isComboObjectiveCompleted = false;
        Debug.Log("Entering movement without beat stage");
    }

    private void setupMovementWithBeatStage() {
        currentStage = TutorialStage.MovementWithBeat;
        isTextShowing = true;
        isMovementEnabled = true;
        isBeatEnabled = true;
        isAttackTogglingEnabled = false;
        isComboEnabled = false;
        directionChecklist = new bool[4];
        attackDirectionChecklist = new bool[4];
        isAttackTogglingObjectiveCompleted = false;
        isComboObjectiveCompleted = false;
        Debug.Log("Entering movement with beat stage");
    }

    private void setupTogglingToAttackStage() {
        currentStage = TutorialStage.TogglingToAttack;
        isTextShowing = true;
        isMovementEnabled = false;
        isBeatEnabled = false;
        isAttackTogglingEnabled = true;
        isComboEnabled = false;
        directionChecklist = new bool[4];
        attackDirectionChecklist = new bool[4];
        isAttackTogglingObjectiveCompleted = false;
        isComboObjectiveCompleted = false;
        Debug.Log("Entering toggling to attack stage");
    }

    private void setupNormalAttackStage() {
        currentStage = TutorialStage.NormalAttack;
        isTextShowing = true;
        isMovementEnabled = true;
        isBeatEnabled = true;
        isAttackTogglingEnabled = true;
        isComboEnabled = false;
        directionChecklist = new bool[4];
        attackDirectionChecklist = new bool[4];
        isAttackTogglingObjectiveCompleted = false;
        isComboObjectiveCompleted = false;

        enemy.SetActive(true);

        Debug.Log("Entering normal attack stage");
    }

    private void setupComboAttackStage() {
        currentStage = TutorialStage.ComboAttack;
        isTextShowing = true;
        isMovementEnabled = true;
        isBeatEnabled = true;
        isAttackTogglingEnabled = true;
        isComboEnabled = true;
        directionChecklist = new bool[4];
        attackDirectionChecklist = new bool[4];
        isAttackTogglingObjectiveCompleted = false;
        isComboObjectiveCompleted = false;

        Debug.Log("Entering combo attack stage");
    }

}
