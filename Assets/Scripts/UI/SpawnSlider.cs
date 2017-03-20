using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSlider : MonoBehaviour {

    public GameObject sliderPrefab;
    public List<GameObject> slidersList = new List<GameObject>();
    public RectTransform startRectTrans;


    public GameObject NewSlider() {
        

        GameObject slider = Instantiate(sliderPrefab);
        slider.transform.SetParent(gameObject.transform, false);

        RectTransform sliderRectTransform = slider.GetComponent<RectTransform>();
        Vector3 startPos = startRectTrans.anchoredPosition3D;
        Vector3 addPos = new Vector3(40 * slidersList.Count, 0, 0);

        sliderRectTransform.anchoredPosition3D = startPos + addPos;

        slidersList.Add(slider);

        return slider;
    }
}
