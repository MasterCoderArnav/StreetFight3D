using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image health_UI;
    void Start()
    {
        health_UI = GameObject.FindWithTag(Tags.HEALTH_UI_TAG).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthUIFill(float value)
    {
        value /= 100f;
        if (value < 0)
        {
            value = 0;
        }
        health_UI.fillAmount = value;
    }
}
