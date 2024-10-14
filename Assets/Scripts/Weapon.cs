using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVFX;

    [SerializeField] float raycastRange = 100f;
    [SerializeField] float damage = 50f;

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
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit thingHit;

        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out thingHit, raycastRange))
        {
            CreateHitEffect(thingHit);
            EnemyHealth enemyTarget = thingHit.transform.GetComponent<EnemyHealth>();
            enemyTarget.TakeDamage(damage);
        }
        
    }

    private void CreateHitEffect(RaycastHit thingHit)
    {
        GameObject impact = Instantiate(hitVFX, thingHit.point, Quaternion.identity);
        Destroy(impact, 5f);
    }
}
