using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    BoxCollider bCollider;
    [SerializeField] Vector3 beamSize = new Vector3(3,7,25);

    void Start()
    {
        bCollider= GetComponent<BoxCollider>();
        BoxCollider bc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        bc.enabled = false;
        bc.isTrigger= true;
        bc.size = beamSize;
        bc.center = new Vector3(0, 0, beamSize.z/2);
        //sets centre like this to make it so that when changing the size, z axis extends out from centre
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            SingleChargeShot();
        }   
    }




    void SingleChargeShot()
    {
        bCollider.enabled = true;
        StartCoroutine(disableWithDelay());
    }

    IEnumerator disableWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        bCollider.enabled = false;
    }

}
