using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _mob;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    public GameObject Camera;



    void Update()
    {
        SpawnEnemies();
    }

    // Need to fix spawning in viewport.
    // Add enemy cap count so spawning has a limit.
    

    void SpawnEnemies()
    {
        
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-36f, 62);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(_mob, whereToSpawn, Quaternion.identity);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpawnRestriction")
        {
            Destroy(_mob);
        }
    }
}
