using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTile : ActiveTile {

    public bool isOpen;
    public delegate void DoorEnterEvent ();
    public static event DoorEnterEvent DoorEnter;
    public int doorType;
    public SwitchSprite switchSprites;
    public string doorDirection; //front, left, right 
    public bool wasOpen = false;
    LevelManager levelManager;

    private void Awake() {
        doorType = Random.Range(0, 6);
        isOpen = false;
        wasOpen = false;

        //set door direction
        TilePoint tilePoint = GetComponentInParent<TilePoint>();
        int dirID = (int)tilePoint.tileID.x;
        if (dirID >= 1 && dirID <= 3) doorDirection = "left";
        if (dirID >= 4 && dirID <= 8) doorDirection = "front";
        if (dirID >= 9 && dirID <= 11) doorDirection = "right";

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();                
    }
    
    override public void OwnAction (){

        if (isOpen) {
            levelManager.nextRoomType = doorType;
            LevelManager.roomDirection = doorDirection;
            DoorEnter();
        }
    }

    private void Update() {
        InvokeRepeating("CheckDoors", 0.5f, 0.5f);
    }

    void CheckDoors (){
        if (LevelManager.noBlockerLeft && LevelManager.noEmenyLeft){
            isOpen = true;
            wasOpen = true;
        }
        else
            isOpen = false;
    }
}
