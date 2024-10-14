using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //cached refs
    [SerializeField] Transform target;
    NavMeshAgent nMA;
    Animator anim;

    //params
    [SerializeField] float aggroRange = 5f;
    float distanceToPlayer;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float rotationTime = 5f;

    //states
    bool isAggro = false;

    private void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(target.position, transform.position);
        if (distanceToPlayer <= aggroRange) isAggro = true;
            if (isAggro)
            {
                if (distanceToPlayer <= attackRange)
                {
                    AttackPlayer();
                    anim.SetBool("IsAttacking", true);
            }
            if (distanceToPlayer <= aggroRange)
            {
                ChasePlayer();
                anim.SetBool("IsMoving", true);
            }
            else
            {
                isAggro = false;
                anim.SetBool("IsMoving", false);
                anim.SetBool("IsAttacking", false);
            }
            
            }


    }

    void AttackPlayer()
    {
        
    }

    void ChasePlayer()
    {
        RotateToFacePlayer();
        nMA.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void RotateToFacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion currentRotation = transform.rotation;
        Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * rotationTime);
    }

    public void OnDamageTaken()
    {
        ChasePlayer();
    }
}
