using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimondCounter : MonoBehaviour {

    public Text text;
    public Animator animator;

    public static int treasureCount;
    public int currentCount;

    void Awake(){
        treasureCount = 0;
        currentCount = 0;
        text.text = treasureCount.ToString();
    }

    void Update(){
        if (treasureCount != currentCount){
            text.text = treasureCount.ToString();
            currentCount = treasureCount;
            animator.Play("pup");
        }
    }
}
