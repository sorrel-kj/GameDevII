using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Gun Data")]
public class GunData : ScriptableObject
{
    public float range = 1000f;
    public int ammo_per_clip = 12;
}
