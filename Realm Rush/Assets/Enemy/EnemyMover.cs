using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;
    Enemy enemy;
    void OnEnable()
    {

        //instead of using invoke you can use this
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    void Start(){
        enemy = GetComponent<Enemy>();
    }

    void FindPath(){
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform){
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart(){
        transform.position = path[0].transform.position;
    }
    //coroutine
    void FinishPath()
    {
        enemy.PenalizeGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
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
