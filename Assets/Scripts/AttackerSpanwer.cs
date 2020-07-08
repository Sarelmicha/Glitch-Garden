using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpanwer : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
  
    [SerializeField] Attacker[] attackersPrefab;
    [SerializeField] int maxYPosition = 5;
    [SerializeField] int minYPosition = 2;
    



    IEnumerator Start()
    {
        while (spawn)
        {
            
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();

        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {

        var attackerIndex = Random.Range(0, attackersPrefab.Length);
        Spawn(attackersPrefab[attackerIndex]);

    }

    private void Spawn(Attacker attacker)
    {

        Attacker newAttacker;
        if (attacker.GetComponent<Fox>())
        {
            newAttacker = Instantiate(
            attacker, transform.position + new Vector3(0, 0.3f, 0), transform.rotation) as Attacker;

        }
        else if (attacker.GetComponent<Bandit>())
        {
            newAttacker = Instantiate(
            attacker, transform.position + new Vector3(-2.0f, 0.3f, 0), transform.rotation) as Attacker;
        }
        else
        {
            newAttacker = Instantiate(
           attacker, transform.position, transform.rotation) as Attacker;
        }
        

        newAttacker.transform.parent = transform;

    }
}
