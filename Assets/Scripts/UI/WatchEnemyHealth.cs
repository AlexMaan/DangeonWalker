using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchEnemyHealth : MonoBehaviour {

    public Slider slider;
    public int currentEnemyHealth;
    public int maxEnemyHealth;
    public int lastEnemyHealth;

    public void SetMaxHealth(int value) {
        maxEnemyHealth = value;
    }
    
    public void SetHealthSlider(int value) {
      slider.value = (float)value / maxEnemyHealth;
      lastEnemyHealth = value;
    }

    private void OnEnable(){
        DoorTile.DoorEnter += DeleteSlider;
    }
    private void OnDisable (){
        DoorTile.DoorEnter -= DeleteSlider;
    }
    

    void DeleteSlider() {
        SpawnSlider spawnSlider = GetComponentInParent<SpawnSlider>();
        spawnSlider.slidersList.Remove(this.gameObject);
        Destroy(gameObject);
        
    }
}
