using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{

    FirstPersonController fpc;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 30f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
    }

    void Zoom()
    {
        if(Input.GetMouseButtonDown(1))
        {
            fpc.m_Camera.fieldOfView = zoomedIn;
            fpc.m_MouseLook.XSensitivity = zoomedInSensitivity;
            fpc.m_MouseLook.YSensitivity = zoomedInSensitivity;
            
        }
        else if(Input.GetMouseButtonUp(1))
        {
            fpc.m_Camera.fieldOfView = zoomedOut;
            fpc.m_MouseLook.XSensitivity = zoomedOutSensitivity;
            fpc.m_MouseLook.YSensitivity = zoomedOutSensitivity;
        }
    }
}
