using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTile : ActiveTile {

    public int healPower;
    int healCounter;
    public Animator animator;
    bool inactive = false;
    HeroController herocontroller;
    int startHealPower;    

    private void OnEnable(){
        LevelManager.FireTurn += HealTurn;
        healPower = Random.Range(healPower - 5, healPower + 5);
        startHealPower = healPower;
        herocontroller = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroController>();
    }
    private void OnDisable(){
        LevelManager.FireTurn -= HealTurn;
    }
    
    void HealTurn(){
        healCounter++;
        if (healCounter >= Random.Range(5f,7f) && !inactive){
            healPower = startHealPower / 2;
            animator.Play("heal_shrink");
        }
        if (healCounter >= Random.Range(10f, 14f) && !inactive)
        {
            healPower = 0;
            animator.Play("heal_end");
            inactive = true;
            Destroy(gameObject, 0.5f);            
        }
    }
    
    override public void OwnAction (){
        LevelManager.PlusOneTurn();
        herocontroller.heroHealth += healPower;
        if (herocontroller.heroHealth >= herocontroller.maxhealth)
            herocontroller.heroHealth = herocontroller.maxhealth;
        animator.Play("heal_end");
        inactive = true;
        Destroy(gameObject, 0.5f);
    }
}
