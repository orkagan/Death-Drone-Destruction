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

    public int _enemyCount = 0;

    ///Singleton Setup
    //Staticly typed property setup for EnemySpawner.Instance
    private static EnemySpawner _instance;
    public static EnemySpawner Instance
    {
        get => _instance;
        private set
        {
            //check if instance of this class already exists and if so keep orignal existing instance
            if (_instance == null)
            {
                _instance = value;
            }
            else if (_instance != value)
            {
                Debug.Log($"{nameof(EnemySpawner)} instance already exists, destroy the duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Instance = this; //sets the static class instance
    }

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
            _enemyCount++;
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-36f, 62);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(_mob, whereToSpawn, Quaternion.identity);
        }

    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "SpawnRestriction")
    //    {
    //        Destroy(_mob);
    //    }
    //}
}
