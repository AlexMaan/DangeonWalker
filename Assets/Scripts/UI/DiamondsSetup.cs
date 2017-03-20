using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondsSetup : MonoBehaviour {

    public Text text;
    public int treasureValue;

    private void Awake(){
        int randomValue = Random.Range(1, 11);
        treasureValue = Mathf.RoundToInt(randomValue + (randomValue * LevelProgress.currentDifficulty * 0.2f)) * 10;

        text.text = treasureValue.ToString();
    }
}
