using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyTile : ActiveTile {

    EnemyController childEnemy;
    WeaponPanelOperator weaponPowerOperator;
    public TileSetup tilesetup;

    private void Awake(){
        weaponPowerOperator =(WeaponPanelOperator) FindObjectOfType(typeof(WeaponPanelOperator));
    }

    override public void OwnAction (){

        childEnemy = GetComponentInChildren<EnemyController>();
        if (childEnemy != null && Time.time >= LevelManager.turnPauseTime) {
            AttackEnemy();
            WeaponPanelOperator.activeWeapon.AttackWeapon();
            LevelManager.PlusOneTurn();

        }
    }

    void AttackEnemy () {
        weaponPowerOperator.SetWeaponPower();
        childEnemy.TakeDamage(WeaponPanelOperator.weaponPower, tilesetup.TileID, HeroController.currentPositionID);

    }
}

