using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCanvas : MonoBehaviour {

    public Text roomsResult;
    public Text treasureResult;
    public Text hiscores;
    LevelProgress levelProgress;
    public GameObject childParent;

    void Awake(){
        childParent.SetActive(false);
        LoadSaveHiscore(0);
        levelProgress = FindObjectOfType<LevelProgress>();
        //SceneManager.sceneLoaded += SetInactive;
    }

    //public void SetInactive(Scene scene, LoadSceneMode sceneMode){
    //    gameObject.SetActive(false);
    //}
    void Start(){
        childParent.SetActive(false);
    }

    public void OnRoundEnd(){
        childParent.SetActive(true);
        roomsResult.text = (levelProgress.roomsCount +1).ToString();
        treasureResult.text = DimondCounter.treasureCount.ToString();
        LoadSaveHiscore(DimondCounter.treasureCount);
        LoadSaveHiscore(0);
        hiscores.text = PlayerPrefs.GetInt("Hiscores").ToString();
        HeroController.isDead = false;
    }


    void LoadSaveHiscore(int roundScores) {
        if (roundScores > PlayerPrefs.GetInt("Hiscores"))
              PlayerPrefs.SetInt("Hiscores", DimondCounter.treasureCount);
    }
}
