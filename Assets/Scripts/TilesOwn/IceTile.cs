using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTile : ActiveTile {

    public int coolPower;
    public int startSize;
    public Animator animator;
    public ParticleSystem iceHit;
    WeaponSlot[] allWeapons;


    private void OnEnable(){        
        startSize = Random.Range(1, 4);
        CheckSize();
        allWeapons = FindObjectsOfType<WeaponSlot>();
        //LevelManager.FireTurn += IceTurn;      
    }
    //private void OnDisable(){
    //    LevelManager.FireTurn -= IceTurn;
    //}
    //void IceTurn(){
    //}

    override public void OwnAction (){
        LevelManager.PlusOneTurn();
        iceHit.gameObject.SetActive(true);
        Invoke("OffParticles", iceHit.main.duration);
        foreach (WeaponSlot weapon in allWeapons){
            weapon.weaponStamina -= coolPower;           
        }
        startSize--;
        CheckSize();
    }

    void OffParticles(){
        iceHit.gameObject.SetActive(false);
    }

    void CheckSize(){
        switch (startSize){
            case 0:
                animator.Play("ice_end");
                Destroy(gameObject, 0.5f);
                break;
            case 1:
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                break;
            case 2:
                transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 3:
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                break;
            default:
                break;
        }
        if (startSize < 0){
            Destroy(gameObject, 0.5f);
        }
    }
}
