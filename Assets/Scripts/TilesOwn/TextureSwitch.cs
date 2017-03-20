using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwitch : MonoBehaviour {

    public Sprite[] spriteVariants;

	void Awake () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
        spriteRenderer.sprite = spriteVariants [Random.Range (0, spriteVariants.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
