using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HighlightObject : MonoBehaviour {
    public float animationTime = 1f;
    public float threshold = 1.5f;

    private HighlightController controller;
    private Material material;
    private Color normalColor;
    private Color selectedColor;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        controller = FindObjectOfType<HighlightController>();

        normalColor = material.color;
        selectedColor = new Color(
            Mathf.Clamp01(normalColor.r * threshold),
            Mathf.Clamp01(normalColor.g * threshold),
            Mathf.Clamp01(normalColor.b * threshold)
            );
    }

    private void Start()
    {
        //StartHighlight();
    }

    public void StartHighlight()
    {
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", selectedColor,
            "time", animationTime,
            "easeType", iTween.EaseType.linear,
            "loopType", iTween.LoopType.pingPong
            ));
    }

    public void StopHighlight()
    {
        iTween.Stop(gameObject);
        material.color = normalColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.SelectObject(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            controller.SelectObject(this);
        }
    }
}
