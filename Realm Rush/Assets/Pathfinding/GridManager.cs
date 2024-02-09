using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    Dictionary<Vector2Int,Node> grid = new Dictionary<Vector2Int, Node>();
    void Awake(){
        CreateGrid();
    }

    void CreateGrid(){

    }
}
