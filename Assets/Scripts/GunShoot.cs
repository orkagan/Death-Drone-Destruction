using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    BoxCollider bCollider;
   

    void Start()
    {
        bCollider= GetComponent<BoxCollider>();
        BoxCollider bc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        bc.enabled = false;
        bc.isTrigger= true;
        bc.center = new Vector3(0, 0, 13);
        bc.size = new Vector3(3, 7, 25);
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
    }

}
