using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;

    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
