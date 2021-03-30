using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAmmoDrop : Drop
{
    protected override void DropAbility(Collider collider)
    {
        collider.GetComponentInChildren<Ammo>().MaxAmmo();
        collider.GetComponentInChildren<Weapon>().UpdateAmmoNumbers();
        Destroy(gameObject);
    }
}
