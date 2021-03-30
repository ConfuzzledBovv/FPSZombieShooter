using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        PauseAssets();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void PauseAssets()
    {
        FindObjectOfType<FirstPersonController>().playing = false;
        FindObjectOfType<Weapon>().playing = false;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }
}
