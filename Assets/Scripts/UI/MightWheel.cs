using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MightWheel : MonoBehaviour {

    int turnCounter;
    int wheelZangle;
    public GameObject wheel;
    public float turnStep;
    public float turnValue;
    public float rotationSpeed;
    public int mightWheelState;
    public GameObject[] wheelEffects;
    public Animator animator;
    public float weaponPowerMult = 1;
    public WeaponPanelOperator weaponPanel;
    public HeroController heroController;
    public int healAmount;
    public int illAmount;
    public float enemyPowerMult;

    void OnEnable(){
        LevelManager.FireTurn += WheelTurn;
        animator.SetInteger("wheelState", 0);
        heroController = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroController>();

    }

    void WheelTurn(){
        turnCounter++;
        if (mightWheelState == 2) heroController.HealHero(healAmount);
        if (mightWheelState == -2) heroController.HealHero(-illAmount);
        if (turnCounter >= turnStep){
            turnCounter = 0;
            StopCoroutine("WheelRotation");
            StartCoroutine("WheelRotation");            
        }               
    }

    IEnumerator WheelRotation(){
        float targetAngle = wheel.transform.rotation.eulerAngles.z - turnValue;
        if (targetAngle < 0) targetAngle = 360 + targetAngle;
        float currentAngle = wheel.transform.rotation.eulerAngles.z;
        if (wheel.transform.rotation.eulerAngles.z < turnValue) currentAngle = wheel.transform.rotation.eulerAngles.z + 360;

        while (currentAngle > targetAngle +0.5f) {
            wheel.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
            currentAngle = wheel.transform.rotation.eulerAngles.z;
            yield return null;            
             }
        wheel.transform.eulerAngles = new Vector3(0, 0, targetAngle);

        bool specCase = false;
        if (targetAngle <= 301 && targetAngle >= 239) { mightWheelState = -1; specCase = true; }
        if (targetAngle <= 286 && targetAngle >= 254) { mightWheelState = -2; specCase = true; }
        if (targetAngle <= 121 && targetAngle >= 59) { mightWheelState = 1; specCase = true; }
        if (targetAngle <= 106 && targetAngle >= 74) { mightWheelState = 2; specCase = true; }
        if (specCase == false && mightWheelState != 0) { mightWheelState = 0; }

        switch (mightWheelState){
            case -1:
                enemyPowerMult = 1.5f;
                animator.SetInteger("wheelState", -1); break;
            case -2:
                enemyPowerMult = 1.5f;
                animator.SetInteger("wheelState", -2); break;
            case 1:
                weaponPowerMult = 1.5f;
                weaponPanel.SetWeaponPower();
                animator.SetInteger("wheelState", 1); break;
            case 2:
                weaponPowerMult = 1.5f;
                weaponPanel.SetWeaponPower();
                animator.SetInteger("wheelState", 2); break;
            default:
                weaponPowerMult = 1;
                enemyPowerMult = 1;
                weaponPanel.SetWeaponPower();
                animator.SetInteger("wheelState", 0); break;                
        }
    }
}
