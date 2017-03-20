using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconDoorClose : MonoBehaviour {

    public Sprite[] textures;
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = textures[0];
        Invoke("CloseDoor", 0.7f);
    }

    void CloseDoor(){
        spriteRenderer.sprite = textures[1];
    }


}
