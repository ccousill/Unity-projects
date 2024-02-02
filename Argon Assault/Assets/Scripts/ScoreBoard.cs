using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    void Start(){
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "start";
    }
    public void IncreaseScore(int amountToIncrease){
        score += amountToIncrease;
        scoreText.text = score.ToString();
    }

    public void printScore(){
        Debug.Log(score);
    }
    
}
