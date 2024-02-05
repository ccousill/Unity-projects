using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    void Start()
    {
        PrintWaypointName();
        InvokeRepeating("PrintWaypointName",0,1f);
    }
    void PrintWaypointName(){
        foreach(Waypoint waypoint in path){
            Debug.Log(waypoint.name);
        }
    }
}
