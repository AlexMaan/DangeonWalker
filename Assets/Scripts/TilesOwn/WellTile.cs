using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellTile : ActiveTile {

    private void Awake() {

        //LevelManager.FireTurn += WellTurn;
    }


    void WellTurn() {

        Vector3 wellScale = new Vector3(1.5f, 1.5f, 1.5f);
        Vector3 addScale = new Vector3(0.1f, 0.1f, 0.1f);

        if (transform.localScale != wellScale) { transform.localScale += addScale; }
        else transform.localScale = new Vector3 (1,1,1);
    }

    override public void OwnAction (){

        print ("its Magic!");
    }
}

