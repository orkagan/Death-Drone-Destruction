using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public GameObject beamPrefab;
    
    CharacterController _charC;
    bool _aiming;
    bool _onCoolDown;
    Vector3 _direction;
    Coroutine _chargingCoroutine = null;
    Animator _anim;
    [SerializeField] int _chargeLevel;

    public float speed = 5f;
    public float gravity = 8f;
    public float chargeTime = 1; //seconds to wait per level of charge
    public float coolDown = 1f; //seconds to wait to fire another shot

    public bool fullHealth = true;
    public bool threeQuarterHealth = false;
    public bool halfHealth = false;
    public bool quarterHealth = false;


    SFXHandler sfxHandler;
    HealthBar healthBar;

    
    // Start is called before the first frame update
    void Start()
    {
        _charC = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        _aiming = false;
        _onCoolDown = false;

        healthBar= FindObjectOfType<HealthBar>();
        fullHealth = true;
        threeQuarterHealth = false;
        halfHealth = false;
        quarterHealth = false;

        sfxHandler = FindObjectOfType<SFXHandler>();
}

    // Update is called once per frame
    void Update()
    {
        #region Movement
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
        //setting anim parameters
        _anim.SetFloat("moveSpeed", _charC.velocity.magnitude);

        //check to stop it from resetting rotation when not moving
        if(_direction.magnitude>0.4f)
        {
            //rotate the character to face movement direction
            transform.rotation = Quaternion.LookRotation(_direction);
        }

        //gravity
        if (!_charC.isGrounded)
        {
            _charC.Move(new Vector3(0,-gravity * Time.deltaTime,0));
        }
        #endregion

        //do aiming gun stuff
        if (Input.GetButton("Fire1") && !_onCoolDown && _chargeLevel<=0)
        {
            _aiming = true;
            _chargeLevel = 1;
            if(_chargingCoroutine!=null) StopCoroutine(_chargingCoroutine);
            _chargingCoroutine = StartCoroutine(ChargingShot());
            GetComponentInChildren<RedHollowControl>().Play_Charging(); //just the beam visual
            
            sfxHandler.ChargeGun(); // Starts gun charge audio clip

        }
        else if (!Input.GetButton("Fire1") && _aiming)
        {
            _aiming = false;
            //firing the shot code to go here
            StopCoroutine(_chargingCoroutine);
            if (_chargeLevel > 0)
            {
                GetComponentInChildren<GunShoot>().SingleChargeShot(); //jank placeholder shooting
                _onCoolDown = true;
                StartCoroutine(ShotCooldown());
            }
            else
            {
                GetComponentInChildren<RedHollowControl>().Play_Idle(); //stop the beam visual
            }
            _chargeLevel = 0;
            
            sfxHandler.UnchargeGun(); // Stops gun Charge Audio Clip
            
        }


        //setting anim parameters
        _anim.SetBool("isAiming", _aiming);
    }
    IEnumerator ChargingShot()
    {
        while (_aiming)
        {
            yield return new WaitForSeconds(chargeTime);
            if (_chargeLevel < 3)
            {
                _chargeLevel++;
            }
            else
            {
                GetComponentInChildren<RedHollowControl>().Finish_Charging(); //final charge stage visual
            }
        }
    }
    IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(coolDown);
        _onCoolDown = false;
    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collision");
            healthBar.LoseHealth();
        }

    }

    

}
