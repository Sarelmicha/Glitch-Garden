using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] int starCost = 100;

    public void AddStars(int amount)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        if (starDisplay)
        {
            starDisplay.AddStars(amount);
        }
    }

    public int GetStarCost()
    {
        return starCost;
    }

   
}
