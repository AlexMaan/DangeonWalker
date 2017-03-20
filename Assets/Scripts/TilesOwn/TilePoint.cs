using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePoint : MonoBehaviour {

    public Vector3 pointPosition;
    public bool pointActive;
    public bool isdoor = false;
    public int pointType;
    public GameObject currentTile;
    public TilesCollection tilesCollection;
    public Vector2 tileID;


	void Awake () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
        spriteRenderer.enabled = false; 
        tilesCollection = FindObjectOfType<TilesCollection> (); 
        pointPosition = transform.position;

        if (pointActive) {
            currentTile = Instantiate (tilesCollection.tilesCollection [pointType].preCollection [Random.Range (0, tilesCollection.tilesCollection [pointType].preCollection.Length)], pointPosition, Quaternion.identity, transform);
            TileSetup tileSetup = currentTile.GetComponent<TileSetup> ();
            tileSetup.TileID = tileID;
        }
    }
	
    void Start () {


    }
}
