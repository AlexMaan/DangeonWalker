using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetup : MonoBehaviour {

    public int minEnemyCount;
    public int maxEnemyCount;
    int currEnemyCount;
    public int enemyCount;
    public GameObject[] enemies;
    public List<GameObject> enemySpawned = new List<GameObject>();
    public List<GameObject> moveTilesList = new List<GameObject>();

    private void Start() {

        currEnemyCount = Random.Range(minEnemyCount, maxEnemyCount + 1);

        //list all move_enemy_tiles
        GameObject[] moveTilesArray = GameObject.FindGameObjectsWithTag("Tile_Move_Enemy");
        foreach (GameObject item in moveTilesArray) {
            if (item.GetComponentInParent<RoomSetup>() == this)
            moveTilesList.Add(item); }

        //spawn enemies
        for (int i = 0; i < currEnemyCount; i++)
        {
            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], transform);
            enemySpawned.Add(newEnemy);
        }
    }
}
