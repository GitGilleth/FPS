using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerHealth playerTarget;

    [SerializeField] float playerHealth = 100f;

    public void TakeHit(float damage)
    {
        playerHealth -= damage;
    }
}
