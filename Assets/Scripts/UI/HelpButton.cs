using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour {

    public GameObject help;

	public void OpenHelp(){
        help.SetActive(!help.activeSelf);
    }
}
