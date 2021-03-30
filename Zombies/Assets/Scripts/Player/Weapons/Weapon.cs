using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum WeaponType
{
    basetype,
    burst
}

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] float range = 100;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] protected Ammo ammoSlot;
    [SerializeField] AudioClip shotSound;
    [SerializeField] int reloadDelay = 3;
    [SerializeField] protected float shootDelay = 0.5f;

    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text storedAmmoText;
    protected WeaponType type;

    Animator shootAnim;
    protected bool canShoot = true;
    protected bool canReload = false;
    private bool isReloading = false;

    public bool playing = true;

    protected virtual void Start()
    {
        type = WeaponType.basetype;
        UpdateAmmoNumbers();
    }

    private void OnEnable()
    {
        UpdateAmmoNumbers();
        if(isReloading)
        {
            Reload();
        }
    }

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0) && playing && canShoot)
        {
            StartCoroutine(Shoot());
        }
        if(Input.GetKeyDown(KeyCode.R) && canReload || ammoSlot.ReturnCurrentClip() <= 0 && canReload)
        {
            Reload();
        }

        //Vector3 direction = (new Vector3(firstPersonCamera.transform.position.x - 20, firstPersonCamera.transform.position.y, firstPersonCamera.transform.position.z) - firstPersonCamera.transform.position).normalized;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        //firstPersonCamera.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
    }

    protected IEnumerator Shoot()
    {
        if(ammoSlot.ReturnCurrentClip() > 0)
        {
            canShoot = false;
            canReload = true;
            PlayMuzzleFlash();
            ProcessRayCast();
            //shootAnim.SetTrigger("Shot");
            ammoSlot.RemoveAmmo();
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
            UpdateAmmoNumbers();
        }
        else if(canReload)
        {
            Reload();
        }

        yield return new WaitForSeconds(shootDelay);

        if(type == WeaponType.basetype)
        {
            canShoot = true;    
        }

    }

    protected void Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        canReload = false;
        canShoot = false;
        ammoSlot.Reload(reloadDelay);
        StartCoroutine(ReloadDelay());
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject instantiatedObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(instantiatedObject, 0.2f);
    }

    public void UpdateAmmoNumbers()
    {
        currentAmmoText.text = ammoSlot.ReturnCurrentClip().ToString();
        storedAmmoText.text = ammoSlot.ReturnTotalStoredAmmo().ToString();
    }

    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(reloadDelay);

        canShoot = true;
        UpdateAmmoNumbers();
        isReloading = false;
    }

    public void DoubleDamage()
    {
        StartCoroutine(DoubleDamageTimer());
    }

    IEnumerator DoubleDamageTimer()
    {
        damage *= 2;
        yield return new WaitForSeconds(10);
        damage /= 2;
    }
}
