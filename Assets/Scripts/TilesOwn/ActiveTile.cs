using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTile : MonoBehaviour {

    BoxCollider2D buttonCollider;
    
    void Start(){
        buttonCollider = GetComponent<BoxCollider2D>();
    }

    void OnMouseDown (){
        if (!HeroController.isDead)
        OwnAction ();
    }

    virtual public void OwnAction (){        
    }

    void Update(){
        if (LevelManager.popupON)
            buttonCollider.enabled = false;
        else
            buttonCollider.enabled = true;
    }

}


