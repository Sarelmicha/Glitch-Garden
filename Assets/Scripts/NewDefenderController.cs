using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewDefenderController : MonoBehaviour
{

    [SerializeField] Defender[] defenders;
    [SerializeField] AudioClip newDefenderSound;
    int lastSceneIndex;


    [SerializeField] int delayTime = 5;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        lastSceneIndex = Convert.ToInt32(FindObjectOfType<GameObject>().name);
        Debug.Log("index is " + lastSceneIndex);
        AudioSource.PlayClipAtPoint(newDefenderSound, Camera.main.transform.position);

        SetNewDefenderDetails();
        yield return new WaitForSeconds(delayTime);
        GetComponent<LevelLoader>().LoadSpecificScene(lastSceneIndex + 1);
    }

    private void SetNewDefenderDetails()
    {
        Debug.Log("lastScenindex = " + lastSceneIndex);

        switch (lastSceneIndex)
        {
          
            case 2:
                Debug.Log("HERE!!1!");
                FindObjectOfType<Text>().text = "You have unlocked " + defenders[0].name;
                Instantiate(defenders[0], transform.position, transform.rotation);
                break;
            case 4:
                Debug.Log("HERE!!!2");
                FindObjectOfType<Text>().text = "You have unlocked " + defenders[1].name;
                Instantiate(defenders[1], transform.position, transform.rotation);
                break;
        }   
    }
}
