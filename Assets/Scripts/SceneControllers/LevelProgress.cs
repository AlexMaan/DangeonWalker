using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour {

    public static int currentDifficulty;
    public int difficultyUpCurve = 1;
    public int roomsCount;
    public GameObject endCanvas;
    public GameObject fadePlane;

    void Awake(){
        endCanvas = FindObjectOfType<EndCanvas>().gameObject;
        currentDifficulty = 1;
        roomsCount = 0;
        SceneManager.sceneLoaded += GetReferencePlus;
    }

    void OnEnable(){
        DoorTile.DoorEnter += DifficultyProgress;
       
    }

    void DifficultyProgress(){

        roomsCount++;
        if (roomsCount <= 1 * difficultyUpCurve) currentDifficulty = 1;
        if (roomsCount > 1 * difficultyUpCurve && roomsCount <= 2 * difficultyUpCurve) currentDifficulty = 2;
        if (roomsCount > 2 * difficultyUpCurve && roomsCount <= 3 * difficultyUpCurve) currentDifficulty = 3;
        if (roomsCount > 3 * difficultyUpCurve && roomsCount <= 4 * difficultyUpCurve) currentDifficulty = 4;
        if (roomsCount > 4 * difficultyUpCurve) currentDifficulty = 5;

        print("difficulty up: " + currentDifficulty);
    }

    void Update(){
        if (HeroController.isDead)
            Invoke("RoundEnd", 0.5f);
    }

    void RoundEnd(){
        endCanvas.GetComponent<EndCanvas>().OnRoundEnd();
    }

    public void GetReferencePlus (Scene scene, LoadSceneMode sceneMode) {
        LevelManager.liveEnemies.Clear();
        LevelManager.liveBlockers.Clear();
        endCanvas = FindObjectOfType<EndCanvas>().gameObject;
        fadePlane.SetActive(false);
        fadePlane.SetActive(true);
    }
}
