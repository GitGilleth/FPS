using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] float raycastRange = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit thingHit;
        Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thingHit , raycastRange);
        print(thingHit.transform.name);
    }
}
