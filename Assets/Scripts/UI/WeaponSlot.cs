using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour {

    public WeaponPanelOperator weaponOperator;
    bool isUsing = false;
    public float weaponStamina = 0;
    public float staminaHeatspeed;
    public float staminaCoolspeed;

    private void OnEnable(){
        LevelManager.FireTurn += CoolDown;
    }

    private void OnMouseDown(){
        SetActiveWeapon(); 
    }

    public void SetActiveWeapon(){
        //if (this != WeaponPanelOperator.activeWeapon)
        //    LevelManager.PlusOneTurn();
        WeaponPanelOperator.activeWeapon = this;
        weaponOperator.SelectWeapon(this);
        weaponOperator.SetWeaponPower();
    }

    public void AttackWeapon(){
        isUsing = true;
        weaponStamina += staminaHeatspeed;
        if (weaponStamina > 100)
            weaponStamina = 100;
    }

    void CoolDown(){
        if (!isUsing)
        weaponStamina -= staminaCoolspeed;
        if (weaponStamina < 0)
            weaponStamina = 0;
    }

    private void LateUpdate(){
        isUsing = false;
    }
}
