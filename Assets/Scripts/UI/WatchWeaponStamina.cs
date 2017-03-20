using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchWeaponStamina : MonoBehaviour {

    Slider slider;
    public WeaponSlot weaponSlot;
    public float maxStamina = 100;
    public float lastStamina;

    void Start(){
        slider = GetComponentInChildren<Slider>();
    }
    
    void Update(){
        if (lastStamina != weaponSlot.weaponStamina)
        {
            slider.value = (float)weaponSlot.weaponStamina / maxStamina;
        }

        lastStamina = weaponSlot.weaponStamina;
    }
}
