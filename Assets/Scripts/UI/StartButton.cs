using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public void LoadScene(){
        Invoke("Loading", 0.1f);
    }

    void Loading() { SceneManager.LoadSceneAsync("PlayScene", LoadSceneMode.Single); }
}
