using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Shotgun : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PrimaryFire()
    {
        //Check if no delay
        if (shoot_delay_timer <= 0)
        {
            if (primary_fire_is_shooting || primary_fire_hold)
            {
                shoot_delay_timer = gun_data.primary_fire_delay;
                primary_fire_is_shooting = false;

                for(int i = 0; i < 6; i++)
                {
                    Vector3 dir = Quaternion.AngleAxis(Random.Range(-gun_data.spread, gun_data.spread), Vector3.up) * cam.transform.forward;
                    dir = Quaternion.AngleAxis(Random.Range(-gun_data.spread, gun_data.spread), Vector3.right) * cam.transform.forward;
                    //Raycast
                    ray = new Ray(cam.transform.position, dir);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, gun_data.range))
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.blue, 0.05f);
                    }

                    print(i);
                }

                
                //ammo
                ammo_in_clip--;
                if (ammo_in_clip <= 0) ammo_in_clip = gun_data.ammo_per_clip;
            }
        }


    }
}
