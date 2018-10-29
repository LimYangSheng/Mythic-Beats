﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

    private string[] textList;
    private TextMesh displayText;
    private int currTextIndex;

    void Start() {
        textList = new string[22];
        setupTextList();
        displayText =  this.GetComponent<TextMesh>();
        currTextIndex = 0;
        updateText();
    }

    private void proceedTextIndex() {
        currTextIndex++;
    }

    private void updateText() {
        displayText.text = textList[currTextIndex];
    }

    // returns false if text is turned inactive, true otherwise
    public bool proceedAndDisplayNextText() {
        proceedTextIndex();
        updateText();
        if (displayText.text == "") {
            hideText();
            return false;
        }
        return true;
    }

    public void hideText() {
        transform.parent.gameObject.SetActive(false);
    }

    private void setupTextList() {
        // Movement without beat stage
        textList[0] = "Hello, welcome to the world of Ra-Beats.";
        textList[1] = "I am your familiar in this world, Ra. Nice to meet you!";
        textList[2] = "Oh right, I forgot you can’t speak in here.";
        textList[3] = "You can use the drums you have there to communicate with me. Try using it to tell me how to move!";
        textList[4] = "Try moving me in all four directions";
        textList[5] = "";

        // Movement with beat stage
        textList[6] = "Great! We are musical creatures by nature, so we follow a rhythm of sorts";
        textList[7] = "Try moving all four directions, according to the beat now. If it helps, you can look at the orb behind me to time your drum hits";
        textList[8] = "";

        // Toggling to attack stage
        textList[9] = "Great! Let’s move on to attacks. You need a different set of drums for that";
        textList[10] = "Press the button at the back of the controller";
        textList[11] = "";

        // Normal attack stage
        textList[12] = "Now what you have are attack drums. With those, I can dish out some painful moves";
        textList[13] = "You can switch back to the movement drums anytime by pressing the same button";
        textList[14] = "Let’s try all 4 attacks on the dummy, according to the beat now!";
        textList[15] = "";

        // Combo attack stage
        textList[16] = "Nice. How about we try some fancy combinations?";
        textList[17] = "<List all the combos> LeftRightLeft Right => Fireball etc. You can take breaks inbetween but missing a beat will reset your combination";
        textList[18] = "";

        // Before transition to main game
        textList[19] = "Good job! Remember to keep to the beat. The more you keep to it, the more damage my attacks will deal";
        textList[20] = "Now that you are all ready, let’s go greet Mister Bearowl!";
        textList[21] = "";
    }
}