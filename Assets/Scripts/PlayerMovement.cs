using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController _charC;
    bool _aiming;
    Vector3 _direction;
    public float speed = 5;

    
    
    // Start is called before the first frame update
    void Start()
    {
        _charC = GetComponent<CharacterController>();
        _aiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        //calculates a Vector3 for the direction based on input
        //Input.GetAxis is rounded to nearest integer to make it so there are only 8 directions
        _direction = new Vector3(
            Mathf.Round(Input.GetAxis("Horizontal")),
            0,
            Mathf.Round(Input.GetAxis("Vertical"))
            ).normalized;

        //when not aiming
        if (!_aiming)
        {
            //move player
            _charC.Move(_direction * speed * Time.deltaTime);
        }
        else
        {
            //do aiming gun stuff
        }

        //jank if statement to stop it from resetting rotation when not moving
        if(_charC.velocity.magnitude >= speed)
        {
            //rotate the character to face movement direction
            transform.rotation = Quaternion.LookRotation(_direction);
        }
    }
}
