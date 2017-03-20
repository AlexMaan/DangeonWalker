using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPanel : MonoBehaviour {

    public GameObject[] shields;
    public static int activeShieldsCount = 0;
    public int shieldDamageTimes;


    void Update(){        
        if (shieldDamageTimes >= 5){
            MinusShield();
            shieldDamageTimes = 0;
        }
    }

    public void PlusShield(){
        if (!shields[0].activeSelf){
            shields[0].SetActive(true);
            activeShieldsCount = 1;
        }
        else
            if (!shields[1].activeSelf){
            shields[1].SetActive(true);
            activeShieldsCount = 2;
        }
        else
            if (!shields[2].activeSelf){
            shields[2].SetActive(true);
            activeShieldsCount = 3;
        }
        else
            shieldDamageTimes = 0;
    }


    public void MinusShield(){
        if (shields[2].activeSelf)
        {
            shields[2].SetActive(false);
            activeShieldsCount = 2;
        }
        else
            if (shields[1].activeSelf)
        {
            shields[1].SetActive(false);
            activeShieldsCount = 1;
        }
        else
                if (shields[0].activeSelf){
            shields[0].SetActive(false);
            activeShieldsCount = 0;
        }
    }

}
