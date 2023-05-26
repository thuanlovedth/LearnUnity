using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public void OnClickRestartButton()
    {
        if (GameManager.HasInstance) { GameManager.Instance.RestartGame(); }
    }

    public void OnClickCanceltButton()
    {
        if (GameManager.HasInstance) { GameManager.Instance.EndGame(); }
    }
}
