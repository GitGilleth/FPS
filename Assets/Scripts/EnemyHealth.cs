using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;

    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints = hitPoints - damage;
        GetComponent<EnemyAI>().OnDamageTaken();
    }



    public void Update()
    {
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
            GameObject death = Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(death, 5f);
        }
    }
}
