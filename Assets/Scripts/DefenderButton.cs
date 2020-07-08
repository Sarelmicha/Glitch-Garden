﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{

    const string FIRST_DEFENDER = "Cactus";
    [SerializeField] Defender defenderPrefab;


    private void Start()
    {
        LabelButtonWithCost();
        SetFirstDefender();


    }

    private void SetFirstDefender()
    {
        if (defenderPrefab.name == FIRST_DEFENDER)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
        }

    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + "has no cost text");
        }
        else
        {
  
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41,41,41,255);

        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
