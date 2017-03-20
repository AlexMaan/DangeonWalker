using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager levelManager; 
    public static int turnNomb;
    public static float turnPauseTime;
    int lastTurnNomb;
    public static string roomDirection = "front";
    public Transform front;
    public Transform left;
    public Transform right;
    public GameObject levelPrefab;
    public float roomMoveTime;
    GameObject oldRoom;
    GameObject parentMover;
    GameObject newRoom;
    GameObject hero;
    //float timeUp = 1.5f;
    public static bool noEmenyLeft;
    public static bool noBlockerLeft;
    public static List<GameObject> liveEnemies = new List<GameObject>();
    public static List<GameObject> liveBlockers = new List<GameObject>();
    public int nextRoomType;
    public static bool popupON = false;
    

    public delegate void Turn();
    public static event Turn FireTurn;

    void Awake(){
        DontDestroyOnLoad(gameObject);
        if (levelManager == null)
            levelManager = this;
        else
            Destroy(gameObject);        
    } 

    private void OnEnable() {
        DoorTile.DoorEnter += NextRoomMover;
        //InvokeRepeating ("NextRoomMover", 2, 3);
    }
    
    public static void PlusOneTurn() {
        turnNomb++;
        turnPauseTime = Time.time + 0.2f;
    }
        
    private void Update() {
        if (turnNomb!= lastTurnNomb) {
            FireTurn();
            lastTurnNomb = turnNomb;
        }

        noEmenyLeft = liveEnemies.Count == 0 ? true : false;
        noBlockerLeft = liveBlockers.Count == 0 ? true : false;
    }

    void NextRoomMover() {
        StopCoroutine("RoomMove");
        newRoom = null;
        parentMover = new GameObject();
        if (roomDirection == "front") parentMover.transform.position = front.position;
        if (roomDirection == "left") parentMover.transform.position = left.position;
        if (roomDirection == "right") parentMover.transform.position = right.position;

        GameObject[] moveTilesList = GameObject.FindGameObjectsWithTag("Tile_Move");
        foreach (GameObject tile in moveTilesList){
            Destroy(tile);
        }

        LevelBack levelBack = (LevelBack)FindObjectOfType(typeof(LevelBack));
        oldRoom = levelBack.gameObject;
        oldRoom.transform.SetParent(parentMover.transform);
        newRoom = Instantiate(levelPrefab, parentMover.transform.position, Quaternion.identity, parentMover.transform);
        hero = GameObject.FindGameObjectWithTag("Hero");
        hero.transform.SetParent(parentMover.transform);

        Invoke("StartCoroutineRoomMove", 0.1f);

        Invoke("HeroMoveToStart", 0.5f);
        Animator animator = hero.GetComponentInChildren<Animator>();
        animator.Play("hero_go_end");

    }

    void StartCoroutineRoomMove() { StartCoroutine("RoomMove", parentMover.transform.position); }

    IEnumerator  RoomMove (Vector3 position) {               

        while (Vector3.SqrMagnitude(position - Vector3.zero) > 0.01) {
            //Vector3 velocity = Vector3.zero;
            position = Vector3.Lerp(position, Vector3.zero, roomMoveTime * Time.deltaTime  ); //*45//* timeUp * Time.deltaTime * 200
            parentMover.transform.position = position;
            //if (timeUp >= 0)
            //timeUp = timeUp - (Time.deltaTime );            
            yield return null;
        }
        oldRoom.transform.parent = null;
        newRoom.transform.parent = null;
        hero.transform.parent = null;
        Destroy(oldRoom);
        Destroy(parentMover);        
        //timeUp = 1.5f;
        
    }

    void HeroMoveToStart(){
        HeroController heroConttroller = hero.GetComponent<HeroController>();
        heroConttroller.SetCharacter();
        Animator animator = heroConttroller.GetComponentInChildren<Animator>();
        animator.Play("hero_go_end");
    }

    void ResetLevel(){
        
    }
}
