using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchHeroHealth : MonoBehaviour {

    Slider slider;
    HeroController heroController;
    public int currentheroHealth;
    public int maxHeroHealth;
    public int lastHeroHealth;

	void Start () {
        slider = GetComponentInChildren<Slider>();
        heroController = GameObject.FindGameObjectWithTag("Hero").GetComponent<HeroController>();
        maxHeroHealth = heroController.heroHealth;

	}
	
	
	void Update () {
		if (lastHeroHealth != heroController.heroHealth) {
            slider.value =(float) heroController.heroHealth / maxHeroHealth ;
        }

        lastHeroHealth = heroController.heroHealth;
	}

}
