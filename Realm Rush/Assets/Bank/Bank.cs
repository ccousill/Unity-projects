using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake() {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    public int getCurrentBalance(){
        return currentBalance;
    }
    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withraw(int amount){
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance < 0){
            //Lose game
            ReloadScene();
        }
        UpdateDisplay();
    }

    void UpdateDisplay(){
        displayBalance.text = "Gold: " + currentBalance;
    }

    void ReloadScene(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
