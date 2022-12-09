using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    public GameObject player;
    public AudioClip gunCharge;
    public AudioClip tier1;
    public AudioClip tier2;
    public AudioClip tier3;

   

    AudioSource AS;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AS = GetComponent<AudioSource>();
    }

    public void ChargeGun()
    {
        AudioSource.PlayClipAtPoint(gunCharge, player.transform.position);
    }

    public void UnchargeGun()
    {
        Debug.Log("Uncharge");
        //GameObject.Find("One shot audio").GetComponent<AudioSource>().Stop();
        //finds all game objects with AudioSource and if the sound used is gunCharge then stop them
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();
        if (audioSources.Length==0) return; //if no audio sources found, exit function by returning
        foreach (AudioSource audioSrc in audioSources)
        {
            if (audioSrc.clip.name == gunCharge.name)
            {
                Destroy(audioSrc.gameObject);
            }
        }
    }

    public void ShootTier1()
    {
        AudioSource.PlayClipAtPoint(tier1, player.transform.position);
    }

    public void ShootTier2()
    {
        AudioSource.PlayClipAtPoint(tier2, player.transform.position);
    }

    public void ShootTier3()
    {
        AudioSource.PlayClipAtPoint(tier3, player.transform.position);
    }

}
