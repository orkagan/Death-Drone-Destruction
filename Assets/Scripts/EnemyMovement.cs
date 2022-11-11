using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform _playerlocation;
    [SerializeField] float _speed;
    [SerializeField] float _closeToPlayer;
    float _dist;

    private void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        Debug.Log("Finding player");
        _dist = Vector3.Distance(transform.position, _playerlocation.position);
        if(_dist >= _closeToPlayer)
        {
            Debug.Log("Chasing Player");
            transform.LookAt(_playerlocation);
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
         
    }














}
