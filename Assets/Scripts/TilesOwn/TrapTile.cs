using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : ActiveTile {

    public int fireCount;
    int state;
    public GameObject[] fires;
    public int heroDamage;
    public int enemyDamage;
    HeroController heroController;
    EnemyController[] enemyController;
    public GameObject effect;

    void OnEnable(){
        LevelManager.FireTurn += TrapTurn;
    }
    void OnDisable(){
        LevelManager.FireTurn -= TrapTurn;
    }
    private void OnDestroy(){
        LevelManager.FireTurn -= TrapTurn;
    }

    void Awake(){
        fireCount = Random.Range(-5, 6);
        StateCheck();
        heroController = FindObjectOfType<HeroController>();       
    }

    int StateCheck (){
        
        if (fireCount <= -5){
            fires[0].SetActive(true);
            fires[1].SetActive(false);
            fires[2].SetActive(false);
            fires[3].SetActive(false);
            state = 1;
        }
        if (fireCount <= 0 && fireCount > -5){
            fires[0].SetActive(false);
            fires[1].SetActive(true);
            fires[2].SetActive(false);
            fires[3].SetActive(false);
            state = 2;
        }
        if (fireCount <= 5 && fireCount > 0){
            fires[0].SetActive(false);
            fires[1].SetActive(false);
            fires[2].SetActive(true);
            fires[3].SetActive(false);
            state = 3;
        }
        if (fireCount > 5){
            fires[0].SetActive(false);
            fires[1].SetActive(false);
            fires[2].SetActive(false);
            fires[3].SetActive(true);
            state = 4;
        }
        return state;
    }

    void TrapTurn(){
        
        switch (StateCheck()){
            case 1:
                heroController.TakeDamage(heroDamage);  //* 2
                break;
            case 2:
                heroController.TakeDamage(heroDamage);
                break;
            case 3:
                enemyController = FindObjectsOfType<EnemyController>();
                foreach (EnemyController enemy in enemyController)
                    enemy.TakeDamage(enemyDamage, new Vector2(-100, -100), new Vector2(-100, -100));
                break;
            case 4:
                enemyController = FindObjectsOfType<EnemyController>();
                foreach (EnemyController enemy in enemyController)
                    enemy.TakeDamage(enemyDamage * 2, new Vector2(-100, -100), new Vector2(-100, -100));
                break;
            default:
                break;            
        }
        fireCount--;
        //Vector3 spriteScale = new Vector3(1.5f, 1.5f, 1.5f);
        //Vector3 addScale = new Vector3(0.1f, 0.1f, 0.1f);

        //if (transform.localScale != spriteScale) { transform.localScale += addScale; }
        //else transform.localScale = new Vector3(1, 1, 1);
    }

    override public void OwnAction (){
        fireCount += 3;
        StateCheck();
        Instantiate(effect, transform.position, Quaternion.identity, transform);
        LevelManager.turnNomb++;      
    }
}

