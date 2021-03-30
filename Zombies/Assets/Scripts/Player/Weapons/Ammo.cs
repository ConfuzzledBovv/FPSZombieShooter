using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 12;
    [SerializeField] int maxClipSize = 12;
    [SerializeField] int maximumStoredAmmo = 96;
    [SerializeField] int currentStoredAmmo = 48;

    public int ReturnCurrentClip()
    {
        return ammoAmount;
    }
    public int ReturnTotalStoredAmmo()
    {
        return currentStoredAmmo;
    }

    public void RemoveAmmo()
    {
        ammoAmount--;
    }

    public void RemoveStoredAmmo(int amount)
    {
        for(; amount > 0; amount--)
        {
            if(currentStoredAmmo <= 0)
            {
                return;
            }
            else
            {
                ammoAmount++;
                currentStoredAmmo--;
            }
        }
    }

    public void MaxAmmo()
    {
        currentStoredAmmo = maximumStoredAmmo;
    }

    public bool Reload(int reloadLength)
    {
        StartCoroutine(DelayReload(reloadLength));

        if(ReturnCurrentClip() > 0)
        {
            return true;
        }
        return false;
    }

    IEnumerator DelayReload(int reloadLength)
    {
        yield return new WaitForSeconds(reloadLength);

        if (currentStoredAmmo >= 0)
        {
            int value = maxClipSize - ammoAmount;
            RemoveStoredAmmo(value);
        }
    }
}
