using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : MonoBehaviour
{
    [SerializeField] Transform _playerlocation;
    [SerializeField] float _speed;
    [SerializeField] float _closeToPlayer;
    public GameObject explosionPrefab;
    float _dist;
    int mobValue = 20;

    Rigidbody _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerlocation = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {// Finds the distance to the player, if the distance is greater than the variable, pursue the player.
        Debug.Log("Finding player");
        _dist = Vector3.Distance(transform.position, _playerlocation.position);
        if (_dist >= _closeToPlayer)
        {
            //Look at player, and move forward.
            Debug.Log("Chasing Player");
            transform.LookAt(_playerlocation);
            _rb.AddForce(transform.forward * _speed);
        }

    }

    //This function lowers enemy count when an enemy is destroyed.
    private void OnDestroy()
    {
        EnemySpawner.Instance._enemyCount--;
        HighScoreData.Instance.score += mobValue;

        //instantiate explosion that destroys itself after a delay
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beam"))
        {
            Destroy(gameObject);
        }
    }

}
