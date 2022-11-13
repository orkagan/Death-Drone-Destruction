using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunEffects : MonoBehaviour
{

    ParticleSystem _parsys;
   
    void Start()
    {
        _parsys= GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ShootGun();
        }
    }


    void ShootGun()
    {
        Debug.Log("Particles");
        _parsys.Play();
       
    }

}
