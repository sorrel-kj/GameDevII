using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    //declare variables
    public GunData gun_data;
    public Camera cam;
    private Ray ray;

    //ammo variables
    private int ammo_in_clip;

    // Start is called before the first frame update
    void Start()
    {
        ammo_in_clip = gun_data.ammo_per_clip;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(cam.transform.position, cam.transform.forward * 1000, Color.green);
    }
    public void GetPrimaryFireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) PrimaryFire();
    }
    public void GetSecondaryFireInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) SecondaryFire();
    }

    private void PrimaryFire()
    {
        //Raycast
        ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, gun_data.range))
        {
            Debug.DrawLine(transform.position, hit.point, Color.blue, 0.05f);
        }
        //ammo
        ammo_in_clip--;
        if (ammo_in_clip <= 0) ammo_in_clip = gun_data.ammo_per_clip;
        print(ammo_in_clip);
    }
    private void SecondaryFire()
    {

    }
}
