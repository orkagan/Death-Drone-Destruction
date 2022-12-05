using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    public AudioClip gunCharge;
    public AudioClip tier1;
    public AudioClip tier2;
    public AudioClip tier3;

   

    AudioSource AS;
    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void ChargeGun()
    {
        AudioSource.PlayClipAtPoint(gunCharge, transform.position);
    }

    public void UnchargeGun()
    {
        Debug.Log("Uncharge");
        GameObject.Find("One shot audio").GetComponent<AudioSource>().Stop();
    }

    public void ShootTier1()
    {
        AudioSource.PlayClipAtPoint(tier1, transform.position);
    }

    public void ShootTier2()
    {
        AudioSource.PlayClipAtPoint(tier2, transform.position);
    }

    public void ShootTier3()
    {
        AudioSource.PlayClipAtPoint(tier3, transform.position);
    }

}
