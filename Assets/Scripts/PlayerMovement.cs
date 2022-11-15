using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _charC;
    bool _aiming;
    Vector3 _direction;
    Coroutine _chargingCoroutine = null;
    [SerializeField] int _chargeLevel;

    public float speed = 5;
    public float chargeTime = 2; //seconds to wait per level of charge

    
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
            );

        //move when not aiming
        if (!_aiming)
        {
            //move player
            _charC.Move(_direction.normalized * speed * Time.deltaTime);
        }

        //do aiming gun stuff
        if (Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.R))
        {
            _aiming = true;
            _chargeLevel = 1;
            if(_chargingCoroutine!=null) StopCoroutine(_chargingCoroutine);
            _chargingCoroutine = StartCoroutine(ChargingShot());
        }
        if (Input.GetButtonUp("Fire1")||Input.GetKeyUp(KeyCode.R))
        {
            _aiming = false;
            //firing the shot logic
            StopCoroutine(_chargingCoroutine);
            _chargeLevel = 0;
        }

        //jank if statement to stop it from resetting rotation when not moving
        if(_direction.magnitude>0.4f)
        {
            //rotate the character to face movement direction
            transform.rotation = Quaternion.LookRotation(_direction);
        }
    }
    IEnumerator ChargingShot()
    {
        while (_aiming)
        {
            yield return new WaitForSeconds(chargeTime);
            if (_chargeLevel < 3) _chargeLevel++;
        }
    }

}
