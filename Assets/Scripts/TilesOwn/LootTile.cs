using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTile : ActiveTile {

    public Sprite[] textures;
    public SpriteRenderer spriteRenderer;
    public GameObject treasurePopup;
    GameObject mainCanvas;

    private void Awake(){
        spriteRenderer.sprite = textures[Random.Range(0, textures.Length)];
        mainCanvas = GameObject.FindGameObjectWithTag("MainUI");
    }
    
    override public void OwnAction (){
        LevelManager.PlusOneTurn();
        OpenChest();
        Destroy(gameObject, 0.2f);
    }

    void OpenChest() {
        Instantiate(treasurePopup, transform.position, Quaternion.identity, mainCanvas.transform);
    }
}
