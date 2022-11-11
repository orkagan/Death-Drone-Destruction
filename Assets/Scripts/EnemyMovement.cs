using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform _playerlocation;
    [SerializeField] float _speed;
    [SerializeField] float _closeToPlayer;
    [SerializeField] GameObject _enemySpawnerObj;
    float _dist;

    EnemySpawner _enemySpawner;
    private void Start()
    {
        _enemySpawner = _enemySpawnerObj.GetComponent<EnemySpawner>();
    }
    private void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {// Finds the distance to the player, if the distance is greater than the variable, pursue the player.
        Debug.Log("Finding player");
        _dist = Vector3.Distance(transform.position, _playerlocation.position);
        if(_dist >= _closeToPlayer)
        {
            //Look at player, and move forward.
            Debug.Log("Chasing Player");
            transform.LookAt(_playerlocation);
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
         
    }

    //This function lowers enemy count when an enemy is destroyed.
    private void OnDestroy()
    {
        _enemySpawner._enemyCount--;
    }














}
