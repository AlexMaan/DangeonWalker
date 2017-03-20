using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    public static Vector2 currentPositionID;
    Vector3 currentPosition;    
    public float moveSpeed = 20f;
    public static int heroAttackPower = 3;
    public int heroHealth;
    public int maxhealth;
    public Animator childAnimator;
    public static bool isDead = false;
    public GameObject damageLabelObj;
    ShieldPanel shieldPanel;
    MightWheel mightWheel;

    private void OnEnable() {
        LevelManager.FireTurn += HeroTurnReaction;
    }
    private void OnDisable() {
        LevelManager.FireTurn -= HeroTurnReaction;
    }

    void Start () {
        isDead = false;
        SetCharacter();
        maxhealth = heroHealth;
        shieldPanel = FindObjectOfType<ShieldPanel>();
        mightWheel = FindObjectOfType<MightWheel>();
	}
    public void SetCharacter(){
        childAnimator.Play("hero_go_start");

        // set character position
        GameObject[] moveTilesList = GameObject.FindGameObjectsWithTag("Tile_Move");
        GameObject moveTile = moveTilesList[Random.Range(0, moveTilesList.Length)];
        Vector3 moveTilePosition = moveTile.transform.position;
        GoToStart(moveTilePosition);

        // set character ID
        TileSetup tileSetup = moveTile.GetComponent<TileSetup>();
        currentPositionID = tileSetup.TileID;

        isDead = false;
    }
	
    public void GoToStart (Vector3 startPosition) {
        transform.position = startPosition;
    }
    
    public void MoveHero (Vector3 position) {
        currentPosition = transform.position;
        StopCoroutine("Moving");
        StartCoroutine("Moving", position);
    }

    IEnumerator Moving(Vector3 position) {

        if (!isDead)
        while (currentPosition != position) {
            currentPosition = Vector3.Lerp(currentPosition, position, moveSpeed * Time.deltaTime);
            transform.position = currentPosition;
            yield return null;
        }        
    }

    public void TakeDamage (int damage) {

        if (ShieldPanel.activeShieldsCount != 0){
            shieldPanel.shieldDamageTimes++;
            Animator[] shields = shieldPanel.GetComponentsInChildren<Animator>();
            foreach (Animator shield in shields)
                shield.Play("shield_damage");
        }
        else { 
            if (heroHealth > 0){
                childAnimator.Play("hero_hit");
            }
            int modDamage = Mathf.RoundToInt(damage * mightWheel.enemyPowerMult);
            heroHealth -= modDamage;
            DamageLabel damageLabel = Instantiate(damageLabelObj, transform.position, Quaternion.identity, transform).GetComponent<DamageLabel>();
            damageLabel.DrawDamageLabel(modDamage, Color.red);
            if (heroHealth <= 0){
                isDead = true;
                childAnimator.Play("hero_death");
            }
        }
    }

    public void HealHero (int healAmount){
        heroHealth += healAmount;

        Color darkGreen = healAmount > 0 ? new Color(3f / 255f, 208f / 255f, 4f / 255f) : new Color(10f / 255f, 20f / 255f, 0 );
        DamageLabel damageLabel = Instantiate(damageLabelObj, transform.position + new Vector3(-1, 0, 0), Quaternion.identity, transform).GetComponent<DamageLabel>();
        damageLabel.DrawDamageLabel(healAmount, darkGreen);
    }
    
    void HeroTurnReaction() {
        
    }
    
}



    
