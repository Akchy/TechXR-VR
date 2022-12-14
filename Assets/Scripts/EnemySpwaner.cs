using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject enemyPrefabs, enemies;
    public float enemyBurstCount = 3, spawnTime=5;

    Transform location;
    float updateTime =1;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
            spawnPoints.Add(child);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > updateTime){
            updateTime = Time.time + spawnTime;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy(){
        if(enemies.transform.childCount < enemyBurstCount){

            location = spawnPoints[Random.Range(0, transform.childCount)];
            var enemyInstance = Instantiate(enemyPrefabs, location);
            enemyInstance.transform.SetParent(enemies.transform);
            enemyInstance.transform.LookAt(Vector3.zero);
        }
    }
}
