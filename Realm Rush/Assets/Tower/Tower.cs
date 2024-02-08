using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public bool CreateTower(Tower tower,Vector3 position){
        Bank bank = FindAnyObjectByType<Bank>();
        if(bank == null){
            return false;
        }
        if(bank.getCurrentBalance() >= cost){
            Instantiate(tower.gameObject,position,Quaternion.identity);
            bank.Withraw(cost);
            return true;

        }
            return false;
        
    }
}
