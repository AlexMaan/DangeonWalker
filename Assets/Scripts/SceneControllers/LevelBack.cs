using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class RoomTypes {

//    public GameObject[] Rooms;
//}


public class LevelBack : MonoBehaviour {

    public GameObject[] frontRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject newRoom;
    LevelManager levelManager;    
	
	void Awake () {
        levelManager = FindObjectOfType<LevelManager>();        

        if (LevelManager.roomDirection == "front")
            newRoom = Instantiate(frontRooms[levelManager.nextRoomType], transform.position, Quaternion.identity, transform);
        if (LevelManager.roomDirection == "left")
            newRoom = Instantiate(leftRooms[levelManager.nextRoomType], transform.position, Quaternion.identity, transform);
        if (LevelManager.roomDirection == "right")
            newRoom = Instantiate(rightRooms[levelManager.nextRoomType], transform.position, Quaternion.identity, transform);
    }
	

	
}
