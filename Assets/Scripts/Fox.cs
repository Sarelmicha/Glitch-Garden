﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        GameObject otherObject = otherCollider.gameObject;

        //if this is a gravestone jump over
        if (otherObject.GetComponent<Gravestone>() != null)
        {
            Jump();
        }

        else if (otherObject.GetComponent<Defender>() != null)
        {     
            //Attack Defender
            GetComponent<Attacker>().Attack(otherObject);
        }
    }

    public void Jump()
    {
        GetComponent<Animator>().SetTrigger("jumpTrigger");
    }
}
