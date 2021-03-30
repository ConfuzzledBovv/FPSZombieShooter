using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");
        if(hitPoints <= 0)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetBool("dead", true);
            anim.SetInteger("deadType", Random.Range(1, 3));

            GetComponentInParent<AIDrops>().CheckDrop();

            BroadcastMessage("HasDied");
            Destroy(gameObject, 5f);
        }
    }
}
