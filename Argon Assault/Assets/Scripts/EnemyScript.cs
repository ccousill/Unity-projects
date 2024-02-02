using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int points = 5;
    [SerializeField] int hitPoints = 5;
    ScoreBoard scoreBoard;
    void Start(){
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1){
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints--;
        scoreBoard.IncreaseScore(points);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

}
