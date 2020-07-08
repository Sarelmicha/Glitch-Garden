using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpanwer myLaneSpanwer;
    Animator animator;

    GameObject projectilesParent;
    const string PROJECTILES_PARENT_NAME = "projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
           
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpanwer[] spawners = FindObjectsOfType<AttackerSpanwer>();

        foreach (AttackerSpanwer spanwer in spawners)
        {
            bool IsCloseEnough = Mathf.Abs(spanwer.transform.position.y - transform.position.y) <= Mathf.Epsilon;
            if (IsCloseEnough)
            {
                myLaneSpanwer = spanwer;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpanwer.transform.childCount  <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectilesParent.transform;

    }


}
