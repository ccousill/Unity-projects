using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold(){
        if(bank == null) {return;}
        bank.Deposit(goldReward);

    }

    public void PenalizeGold(){
        if(bank == null) {return;}
        bank.Withraw(goldPenalty);

    }
}
