using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField][Range(0f,50f)] int poolSize = 5;
    [SerializeField] [Range(.01f,30f)]float spawnTimer = 1f;
    GameObject[] pool;

    void Awake(){
        PopulatePool();
    }
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool(){
        pool = new GameObject[poolSize];
        for(int i = 0; i< pool.Length;i++){
            pool[i] = Instantiate(enemyPrefab,transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool(){
        for(int i = 0; i< pool.Length;i++){
            if(pool[i].activeInHierarchy == false){
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnemy(){
        while(true){
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
