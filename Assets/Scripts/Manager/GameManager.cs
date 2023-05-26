using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    private const string CherryKey = "Cherry";

    private int cherries = 0;
    public int Cherries => cherries;
    private bool isPlay = false;
    public bool IsPlaying => isPlay;

    protected override void Awake()
    {
        base.Awake();
        cherries = PlayerPrefs.GetInt(CherryKey, 0);
    }

    public void UpdateCherries(int value)
    {
        cherries = value;
    }

    public void StartGame()
    {
        isPlay = true;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (isPlay == true)
        {
            isPlay = false;
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        if (!isPlay)
        {
            isPlay = true;
            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
        ChangeScene("Menu");
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveMenuPanel(true);
            UIManager.Instance.ActiveGamePanel(false);
            UIManager.Instance.ActiveVictoryPanel(false);
            UIManager.Instance.ActiveLosePanel(false);
        }
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(CherryKey, cherries);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
