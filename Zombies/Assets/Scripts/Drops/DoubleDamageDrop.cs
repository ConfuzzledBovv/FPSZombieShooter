using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageDrop : Drop
{
    protected override void DropAbility(Collider collider)
    {
        collider.GetComponentInChildren<Weapon>().DoubleDamage();
        Destroy(gameObject);
    }
}
