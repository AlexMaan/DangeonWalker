using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector2 currentPositionID;
    public int enemyHealth;
    public Animator childAnimator;
    public Animator heroAnimator;
    public HeroController heroController;
    public GameObject damageLabelObj;
    bool isDead = false;
    public int attackState;
    public int enemyAttackPower;
    public float AttackPowerCurve = 1;
    float sizeModifier;
    Transform resizer;
    WatchEnemyHealth newSlider;
    SpawnSlider spawnSlider;
    //MightWheel mightWheel;
    public int minAttackSeed;
    public int maxAttackSeed;


    private void OnEnable() {
        LevelManager.FireTurn += EnemyTurnReaction;
    }
    private void OnDisable() {
        LevelManager.FireTurn -= EnemyTurnReaction;
    }

    void Start () {
        // set character position
        RoomSetup roomSetup = GetComponentInParent<RoomSetup>();
        GameObject moveTile = roomSetup.moveTilesList[Random.Range(0, roomSetup.moveTilesList.Count)];
        roomSetup.moveTilesList.Remove(moveTile);
        if (moveTile != null) {
            Vector3 moveTilePosition = moveTile.transform.position;
            transform.position = moveTilePosition;
        }

        // set character ID
        TileSetup tileSetup = moveTile.GetComponent<TileSetup>();
        currentPositionID = tileSetup.TileID;
        transform.SetParent(moveTile.transform);

        // get hero components
        heroAnimator = GameObject.FindGameObjectWithTag("Hero").GetComponentInChildren<Animator>();
        heroController = heroAnimator.GetComponentInParent<HeroController>();

        //get health_slider
        spawnSlider = (SpawnSlider)FindObjectOfType(typeof(SpawnSlider));
        newSlider = spawnSlider.NewSlider().GetComponent<WatchEnemyHealth>();
        newSlider.SetMaxHealth(enemyHealth);

        LevelManager.liveEnemies.Add(gameObject);

        //check difficulty : power, health & size
        sizeModifier = Random.Range(1, (10f + LevelProgress.currentDifficulty) / 10f);
        enemyAttackPower =(int) Mathf.Round(enemyAttackPower * LevelProgress.currentDifficulty * AttackPowerCurve * sizeModifier);
        enemyHealth = (int)Mathf.Round(enemyHealth * LevelProgress.currentDifficulty * AttackPowerCurve * sizeModifier);
        resizer = transform.FindChild("EnemyParent");
        resizer.localScale = new Vector3(resizer.localScale.x * sizeModifier, resizer.localScale.y * sizeModifier, resizer.localScale.z * sizeModifier);

        //mightWheel = FindObjectOfType<MightWheel>();
    }

    public void TakeDamage(int damage, Vector2 enemyID, Vector2 heroID) {

        if (enemyHealth > 0) {
            //childAnimator.Play("hero_hit");
            heroAnimator.Play("hero_atack");
        }

        Color labelColor = Color.white;
        int modDamage = damage;
        if (enemyID.x == heroID.x && WeaponPanelOperator.activeWeapon.GetComponentInChildren<WeaponPrefab>().weaponType == 1 && heroID != new Vector2 (-100, -100)){
            labelColor = Color.yellow;
            modDamage = damage * 2;
        }
        if (enemyID.x != heroID.x && WeaponPanelOperator.activeWeapon.GetComponentInChildren<WeaponPrefab>().weaponType == 2 && heroID != new Vector2(-100, -100))
        {
            labelColor = Color.yellow;
            modDamage = damage * 2;
        }

        enemyHealth -= modDamage;
        newSlider.SetHealthSlider(enemyHealth);
        if (!isDead) {
            DamageLabel damageLabel = Instantiate(damageLabelObj, transform.position, Quaternion.identity, transform).GetComponent<DamageLabel>();
            damageLabel.DrawDamageLabel(modDamage, labelColor); }
        if (enemyHealth <= 0) {
            isDead = true;
            childAnimator.Play("hero_death");
            Destroy(this.gameObject, 0.5f);
            LevelManager.liveEnemies.Remove(gameObject);
        }
    }
      
    public void DealDamage() {
        childAnimator.SetTrigger("attackState");
        heroController.TakeDamage(enemyAttackPower);
    }
          
    public void EnemyTurnReaction() {
        //int minAttackSeedMod = mightWheel.mightWheelState == 2 ? minAttackSeed + 1 : minAttackSeed ;
        int random = Random.Range(minAttackSeed, maxAttackSeed);
        if (random == 2)
            attackState++;
        if (!isDead)
        switch (attackState) {
            case 0:
                break;
            case 1:
                Invoke("PlayIdle1", 0.1f);
                break;
            case 2:
                Invoke("PlayIdle2", 0.1f);
                break;
            case 3:                
                DealDamage();
                attackState = 0;
                break;
            case 4:
                Invoke("PlayIdle", 0.5f);
                attackState = 0;
                break;

            default:
                attackState = 0;
                Invoke("PlayIdle", 0.5f);
                break;
        }
    }

    void PlayIdle(){ childAnimator.Play("hero_idle"); }
    void PlayIdle1(){ childAnimator.SetInteger("idleState", 1); }
    void PlayIdle2(){ childAnimator.SetInteger("idleState", 2); }
}
