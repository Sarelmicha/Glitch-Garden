using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 3;
    bool timerFinished;
    bool triggeredLevelFinished = false;


    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            triggeredLevelFinished = true;
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }
}
