using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnClickSettingButton() 
    { 
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(true);
            UIManager.Instance.ActivePausePanel(false);
        }
    }

    public void OnClickResumeButton() 
    {
        if (GameManager.HasInstance && UIManager.HasInstance) 
        { 
            GameManager.Instance.ResumeGame();
            UIManager.Instance.ActivePausePanel(false);
        }
    }

    public void OnClickQuitButton() 
    {
        if (GameManager.HasInstance) { GameManager.Instance.EndGame(); }
    }
}
