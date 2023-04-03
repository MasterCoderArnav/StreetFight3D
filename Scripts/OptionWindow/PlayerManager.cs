using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static PlayerManager instance;
    void Start()
    {
        gameOverPanel.SetActive(false);
        if (!instance)
        {
            instance = this;
        }
    }
}
