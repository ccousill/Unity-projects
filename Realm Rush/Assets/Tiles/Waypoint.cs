using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable{
        get{
            return isPlaceable;
        }
    }

   void OnMouseUp(){
    if(isPlaceable){
        bool isPlaced = tower.CreateTower(tower,transform.position);
        
        isPlaceable = !isPlaced;
    }

   }
}
