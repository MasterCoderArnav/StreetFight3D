using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private PlayerAnimation playerAnimation;
    private EnemyMovement enemyMovement;
    private HealthUI healthUI;

    private bool characterDied;
    public bool is_Player;

    private void Awake()
    {
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
        healthUI = GetComponent<HealthUI>();
    }

    public void applyDamage(float damage, bool knockDown)
    {
        if (characterDied)
        {
            return;
        }

        health -= damage;
        if (is_Player)
        {
            healthUI.healthUIFill(health);
        }
        if (health <= 0)
        {
            playerAnimation.death();
            characterDied = true;
            //if isPlayer then deactivate enemy
            if (is_Player)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
                PlayerManager.instance.gameOverPanel.SetActive(true);
            }
            return;
        }
        if (!is_Player)
        {
            if (knockDown)
            {
                if(Random.Range(0, 5) > 3)
                {
                    playerAnimation.knockDown();
                }
            }
            else
            {
                if(Random.Range(0, 3) > 1)
                {
                    playerAnimation.hit();
                }
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
