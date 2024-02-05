using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    void Start()
    {
        //instead of using invoke you can use this
         StartCoroutine(FollowPath());
    }
    //coroutine
    IEnumerator FollowPath(){
        foreach(Waypoint waypoint in path){
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
