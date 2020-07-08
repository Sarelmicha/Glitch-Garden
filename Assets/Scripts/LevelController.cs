using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioClip levelFinishedSFX;
    [SerializeField] float waitToLoad = 6f;

    int[] newDefendersLevels = { 2, 4 };

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
  


    private void Start()
    {
        
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }


    public void AttackerSpawn()
    {
        numberOfAttackers++;
    }


    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());  
        }
    }

    private IEnumerator HandleWinCondition()
    {
        AudioSource.PlayClipAtPoint(levelFinishedSFX, Camera.main.transform.position);
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        NavigateNextScene();
        
        
    }

    private void NavigateNextScene()
    {

        Debug.Log("index is " + SceneManager.GetActiveScene().buildIndex);

        for (int i = 0; i < newDefendersLevels.Length; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == newDefendersLevels[i])
            {
                FindObjectOfType<LevelLoader>().LoadNewDefenderScene();
                return;
            }
        }
        
       FindObjectOfType<LevelLoader>().LoadNextScene();
        

    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;

    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();


    }

    private void StopSpawners()
    {
        AttackerSpanwer[] spawnerArray = FindObjectsOfType<AttackerSpanwer>();

        foreach (AttackerSpanwer spanwer in spawnerArray)
        {
            spanwer.StopSpawning();
        }
    }

}
