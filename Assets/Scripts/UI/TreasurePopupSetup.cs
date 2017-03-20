using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePopupSetup : MonoBehaviour {

    public Transform slotTransform;
    public GameObject[] weapons;
    public GameObject treasure;
    public GameObject shield;
    int randomInt;
    DiamondsSetup diamonds;
    WeaponPrefab weapon;
    WeaponPanelOperator weaponPanelOperator;
    ShieldPanel shieldPanel;

    void Awake(){
        LevelManager.popupON = true;
        randomInt = Random.Range(1, 8);
        if (randomInt == 1)
           Instantiate(weapons[Random.Range(0, weapons.Length)], transform.position, Quaternion.identity, slotTransform);
        if (randomInt == 2 || randomInt == 3){
            Instantiate(shield, transform.position, Quaternion.identity, slotTransform);
            shieldPanel = FindObjectOfType<ShieldPanel>();            
        }
        if (randomInt != 1 && randomInt != 2 && randomInt != 3)
            Instantiate(treasure, transform.position, Quaternion.identity, slotTransform);

        weaponPanelOperator = FindObjectOfType<WeaponPanelOperator>();
    }

    void OnMouseDown(){
        TakeTreasures();
        LevelManager.popupON = false;
        Destroy(gameObject);
    }

    void TakeTreasures(){
        if (randomInt == 1){
            weapon = GetComponentInChildren<WeaponPrefab>();
            weaponPanelOperator.ChangeWeapon(weapon, weapon.weaponType);
        }
        if (randomInt == 2 || randomInt == 3)
            shieldPanel.PlusShield();
        if (randomInt != 1 && randomInt != 2 && randomInt != 3){ 
            diamonds = FindObjectOfType<DiamondsSetup>();
            DimondCounter.treasureCount += diamonds.treasureValue;
        }

    }
}

