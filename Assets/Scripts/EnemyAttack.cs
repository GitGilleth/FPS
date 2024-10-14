using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform playerTarget;

    [SerializeField] float damage = 25f;

    public void AttackHitAnimEvent(float playerHealth)
    {
        if (playerTarget == null) return;
        playerTarget.TakeHit();
        print("Health is" + playerHealth);

    }
}
