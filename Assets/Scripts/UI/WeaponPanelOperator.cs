using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanelOperator : MonoBehaviour {

    public static WeaponSlot activeWeapon;
    public WeaponSlot[] allWeapons;
    public WeaponSlot defaultweapon;
    public static int weaponPower;
    public Text powerText;
    public MightWheel mightWheel;

    private void Awake(){
        activeWeapon = defaultweapon;
        defaultweapon.GetComponent<Animator>().Play("weapon_slot_select");
        defaultweapon.SetActiveWeapon();
    }

    public void SelectWeapon (WeaponSlot activeWeapon){

        foreach (WeaponSlot weapon in allWeapons){
            if (weapon == activeWeapon)
                weapon.GetComponent<Animator>().Play("weapon_slot_select");
            else
                if (weapon.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("weapon_slot_select"))
                weapon.GetComponent<Animator>().Play("weapon_slot_deselect");
        }
    }

    public void SetWeaponPower(){
        float minPower = activeWeapon.GetComponentInChildren<WeaponPrefab>().minPower * mightWheel.weaponPowerMult;
        float maxPower = activeWeapon.GetComponentInChildren<WeaponPrefab>().maxPower * mightWheel.weaponPowerMult;


        float roundMin = minPower;
        float roundMax = maxPower;

        if (activeWeapon.weaponStamina >= 45){
            minPower = minPower * 0.8f;
            maxPower = maxPower * 0.8f;
        }
        if (activeWeapon.weaponStamina >= 95){
            minPower = minPower * 0.4f;
            maxPower = maxPower * 0.4f;
        }
        roundMin = Mathf.Round(minPower);
        roundMax = Mathf.Round(maxPower);
        if (roundMin < 1) roundMin = 1;
        if (roundMax < 1) roundMax = 1;
        powerText.text = roundMin == roundMax ? Mathf.Round(roundMin).ToString() : roundMin + "-" + roundMax;
        weaponPower = (int) Mathf.Round(Random.Range(roundMin, roundMax));
    }

    public void ChangeWeapon ( WeaponPrefab newWeapon, int weaponType){
        WeaponPrefab oldWeapon;
        WeaponSlot weaponSlot;
        switch (weaponType){
            case 1:
                oldWeapon = allWeapons[0].GetComponentInChildren<WeaponPrefab>();
                newWeapon.transform.SetParent(oldWeapon.transform.parent, false);
                Destroy(oldWeapon.gameObject);
                weaponSlot = newWeapon.GetComponentInParent<WeaponSlot>();
                weaponSlot.weaponStamina = 0;
                break;
            case 2:
                oldWeapon = allWeapons[1].GetComponentInChildren<WeaponPrefab>();
                newWeapon.transform.SetParent(oldWeapon.transform.parent, false);
                Destroy(oldWeapon.gameObject);
                weaponSlot = newWeapon.GetComponentInParent<WeaponSlot>();
                weaponSlot.weaponStamina = 0;
                break;
            case 3:
                oldWeapon = allWeapons[2].GetComponentInChildren<WeaponPrefab>();
                newWeapon.transform.SetParent(oldWeapon.transform.parent, false);
                Destroy(oldWeapon.gameObject);
                weaponSlot = newWeapon.GetComponentInParent<WeaponSlot>();
                weaponSlot.weaponStamina = 0;
                break;
            default:
                break;
        }
    }
}
