using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class ButtonHover : MonoBehaviour
{

    public TextMeshProUGUI descriptionText;
    public string description;

    void Start()
    {
        descriptionText = descriptionText.GetComponent<TextMeshProUGUI>();
    }

    public void OnMouseOver()
    {
        descriptionText.text = description;
    }

}
