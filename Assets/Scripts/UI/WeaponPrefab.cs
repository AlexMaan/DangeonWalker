using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefab : MonoBehaviour {


    [Range(1,3)] public int weaponType;
    public int minPower;
    public int maxPower;
}
