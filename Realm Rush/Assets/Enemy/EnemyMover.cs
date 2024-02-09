using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    List<Node> path = new List<Node>();
    Enemy enemy;
    GridManager gridManager;
    Pathfinding pathfinding;
    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
        
    }
    void Awake(){
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinding = FindObjectOfType<Pathfinding>();
    }

    void RecalculatePath(bool resetPath){
        Vector2Int coordinates = new Vector2Int();
        if(resetPath){
            coordinates = pathfinding.getStartCoordinates();
        }else{
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathfinding.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }

    void ReturnToStart(){
        transform.position = gridManager.GetPositionFromCoordinates(pathfinding.getStartCoordinates());
    }
    //coroutine
    void FinishPath()
    {
        enemy.PenalizeGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        for(int i = 1; i<path.Count;i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
    
    
    
}
