using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    BoxCollider bCollider;
    [SerializeField] Vector3 beamSize = new Vector3(3,7,25);

    SFXHandler sfxHandler;

    void Start()
    {
        bCollider= GetComponent<BoxCollider>();
        if (bCollider == null)
        {
            bCollider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        }
        bCollider.enabled = false;
        bCollider.isTrigger= true;
        bCollider.size = beamSize;
        bCollider.center = new Vector3(0, 0, beamSize.z/2);
        //sets centre like this to make it so that when changing the size, z axis extends out from centre

        sfxHandler = FindObjectOfType<SFXHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SingleChargeShot();
        }   
    }




    public void SingleChargeShot()
    {
        Debug.Log("Pew!");
        bCollider.enabled = true;
        StartCoroutine(disableWithDelay());
        GetComponentInChildren<RedHollowControl>().Dead(); //beam firing visual
        sfxHandler.ShootTier1();// Shoots the first tier sound after charging effect.
        
    }

    IEnumerator disableWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        bCollider.enabled = false;
        Debug.Log("Unpew.");
    }

}
