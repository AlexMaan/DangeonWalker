using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : ActiveTile {

    public Vector2 tileID;
    public Vector3 tilePosition;
    HeroController heroController;
    Vector2 addVector = new Vector2 (1,0);

    private void Awake() {

        heroController = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroController>();
        tilePosition = transform.parent.transform.position;
        
        //get parent ID
        TilePoint parentPoint = GetComponentInParent<TilePoint>();
        tileID = parentPoint.tileID;
          
    }

    override public void OwnAction() {

        Vector2 currentHeroID = HeroController.currentPositionID;
        if (currentHeroID == tileID + addVector || currentHeroID == tileID - addVector) {
            if (Time.time >= LevelManager.turnPauseTime){
                LevelManager.PlusOneTurn();
                tilePosition = transform.parent.transform.position;
                heroController.MoveHero(tilePosition);
                HeroController.currentPositionID = tileID;
            }
        }
    }
}