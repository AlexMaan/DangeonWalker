using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageLabel : MonoBehaviour {

    public TextMesh textMesh;
    public Animator animator;
    public Transform child;
    public MeshRenderer meshRenderer;

    public void DrawDamageLabel (int value, Color color) {

        meshRenderer.sortingLayerName = "UI";
        meshRenderer.sortingOrder = 1;

        child.localScale = new Vector3(child.localScale.x + (value / 15), child.localScale.y + (value / 15), child.localScale.z + (value / 15));
        textMesh.text = value.ToString();
        textMesh.color = color;
        animator.Play("damage_label");

        Destroy(gameObject, 0.6f);

    }
}
