using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstWeapon : Weapon
{
    [SerializeField] float burstDelay = 0.1f;

    protected override void Start()
    {
        type = WeaponType.burst;
    }

    protected override void Update()
    {
        if(Input.GetMouseButtonDown(0) && playing && canShoot)
        {
            StartCoroutine(Repeat());
            canShoot = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && canReload || ammoSlot.ReturnCurrentClip() <= 0 && canReload)
        {
            Reload();
        }
    }

    IEnumerator Repeat()
    {
        for(int i = 0; i < 3; i++)
        {
            StartCoroutine(Shoot());
            yield return new WaitForSeconds(burstDelay);
        }
        canShoot = true;
    }
}
