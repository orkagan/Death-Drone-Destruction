using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    //offset for player position that camera follows (can be tweaked in editor)
    public Vector3 offset = new Vector3(0,20,-5);
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
        //sets camera's position to follow the player with custom offset
        transform.position = player.transform.position + offset;
        //makes the camera's rotation look at the player
        transform.LookAt(player.transform);
    }
}
