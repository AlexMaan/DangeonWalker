using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadePlane : MonoBehaviour {

    public Animator animator;

    void OnEnable(){
        SceneManager.sceneLoaded += Reload;
    }

    public void Reload(Scene scene, LoadSceneMode sceneMode){
        animator.enabled = false;
        animator.enabled = true;
        animator.Play("blank");
    }
}
