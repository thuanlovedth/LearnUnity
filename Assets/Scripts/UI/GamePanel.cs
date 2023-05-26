using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cherriesText;
    [SerializeField]
    private TextMeshProUGUI timeText;

    private float timeRemaining;
    private bool timeisRunning = true;


    private void OnEnable()
    {
        //Dang ky su kien
        ItemCollector.collectCherryDelegate += OnPlayerCollectCherries;
        SetTimeRemain(120);
        timeisRunning = true;
    }

    private void Start()
    {
        cherriesText.text = GameManager.Instance.Cherries.ToString();
    }

    private void Update()
    {
        if (!timeisRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
        else
        {
            timeRemaining = 0;
            timeisRunning = false;
            timeText.text = string.Format("{0:00}:{1:00}", 0, 0);
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_LOSE);
            }
            if (UIManager.HasInstance)
            {
                Time.timeScale = 0f;
                UIManager.Instance.ActiveLosePanel(true);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SetTimeRemain(float value)
    {
        timeRemaining = value;
    }

    private void OnDisable()
    {
        //Huy su kien
        ItemCollector.collectCherryDelegate -= OnPlayerCollectCherries;
    }

    private void OnPlayerCollectCherries(int value)
    {
        cherriesText.text = value.ToString();
    }
}
