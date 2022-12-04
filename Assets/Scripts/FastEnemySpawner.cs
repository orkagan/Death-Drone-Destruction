using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _mob;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 0.1f;
    float nextSpawn = 0.0f;
    public GameObject Camera;

    public int _enemyCount = 0;

    #region Singleton Setup
    //Staticly typed property setup for EnemySpawner.Instance
    private static FastEnemySpawner _instance;
    public static FastEnemySpawner Instance
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
                Debug.Log($"{nameof(FastEnemySpawner)} instance already exists, destroy the duplicate!");
                Destroy(value);
            }
        }
    }
    private void Awake()
    {
        Instance = this; //sets the static class instance
    }
    #endregion

    void Update()
    {
        SpawnEnemies();
    }

    // Need to fix spawning in viewport


    void SpawnEnemies()
    {

        if (Time.time > nextSpawn && _enemyCount <= 49)
        {
            _enemyCount++;
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-36f, 62);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(_mob, whereToSpawn, Quaternion.identity, transform); //spawns enemies as children
        }
    }
}
