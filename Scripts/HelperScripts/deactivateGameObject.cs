using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateGameObject : MonoBehaviour
{
    public float time = 2f;

    void Start()
    {
        Invoke("deactivateAfterTime", time);
    }

    void deactivateAfterTime()
    {
        Destroy(gameObject);
    }
}
