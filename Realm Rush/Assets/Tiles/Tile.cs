using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable;
    GridManager gridManager;
    Pathfinding pathfinding;
    Vector2Int coordinates = new Vector2Int();

    void Awake(){
        gridManager = FindObjectOfType<GridManager>();
        pathfinding = FindObjectOfType<Pathfinding>();
    }

    void Start(){
        if(gridManager != null){
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if(!isPlaceable){
                gridManager.BlockNode(coordinates);
            }
        }
    }
    public bool IsPlaceable{
        get{
            return isPlaceable;
        }
    }

   void OnMouseUp(){
    if(gridManager.GetNode(coordinates).isWalkable && pathfinding.WillBlockPath(coordinates)){
        bool isSuccessful = tower.CreateTower(tower,transform.position);
        if(isSuccessful){
            gridManager.BlockNode(coordinates);
            pathfinding.NotifyReceivers();
        }
    }

   }
}
