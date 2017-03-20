using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSprite : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public Sprite[] spritesArrayCloseFront;
    public Sprite[] spritesArrayOpenFront;
    public Sprite[] spritesArrayCloseLeft;
    public Sprite[] spritesArrayOpenLeft;
    public DoorTile doorTile;
    bool lastState;
    public float dirID;
    public TilePoint tilePoint;



    void Start() {        
        tilePoint = GetComponentInParent<TilePoint>();
        dirID = tilePoint.tileID.x;
        if (dirID >= 1 && dirID <= 3) { spriteRenderer.sprite = spritesArrayCloseLeft[doorTile.doorType]; }
        if (dirID >= 4 && dirID <= 5) { spriteRenderer.sprite = spritesArrayCloseFront[doorTile.doorType]; transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); }
        if (dirID >= 6 && dirID <= 8) { spriteRenderer.sprite = spritesArrayCloseFront[doorTile.doorType]; }
        if (dirID >= 9 && dirID <= 11) { spriteRenderer.sprite = spritesArrayCloseLeft[doorTile.doorType]; transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); }


    }

    private void Update() {
       if (lastState != doorTile.isOpen) {

            if (doorTile.isOpen)
                if (dirID >= 1 && dirID <= 3) { spriteRenderer.sprite = spritesArrayCloseLeft[doorTile.doorType]; }
            if (dirID >= 4 && dirID <= 5) { spriteRenderer.sprite = spritesArrayCloseFront[doorTile.doorType]; }
            if (dirID >= 6 && dirID <= 8) { spriteRenderer.sprite = spritesArrayCloseFront[doorTile.doorType]; }
            if (dirID >= 9 && dirID <= 11) { spriteRenderer.sprite = spritesArrayCloseLeft[doorTile.doorType]; }
            else
                if (doorTile.wasOpen)
                if (dirID >= 1 && dirID <= 3) { spriteRenderer.sprite = spritesArrayCloseLeft[doorTile.doorType]; }
            if (dirID >= 4 && dirID <= 5) { spriteRenderer.sprite = spritesArrayCloseFront[doorTile.doorType]; }
            if (dirID >= 6 && dirID <= 8) { spriteRenderer.sprite = spritesArrayCloseFront[doorTile.doorType]; }
            if (dirID >= 9 && dirID <= 11) { spriteRenderer.sprite = spritesArrayCloseLeft[doorTile.doorType]; }
            else
                        if (dirID >= 1 && dirID <= 3) { spriteRenderer.sprite = spritesArrayOpenLeft[doorTile.doorType]; }
                        if (dirID >= 4 && dirID <= 5) { spriteRenderer.sprite = spritesArrayOpenFront[doorTile.doorType]; }
                        if (dirID >= 6 && dirID <= 8) { spriteRenderer.sprite = spritesArrayOpenFront[doorTile.doorType]; }
                        if (dirID >= 9 && dirID <= 11) { spriteRenderer.sprite = spritesArrayOpenLeft[doorTile.doorType]; }

            lastState = doorTile.isOpen;
        }

    }


}
