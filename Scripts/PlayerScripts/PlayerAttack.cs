using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum COMBO_STATES
{
    None,
    Punch_1,
    Punch_2,
    Punch_3,
    Kick_1,
    Kick_2,
};

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation playerAnimation;

    private bool activateTimerToReset;

    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private COMBO_STATES currentComboState;
    void Awake()
    {
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    private void Start()
    {
        activateTimerToReset = false;
        currentComboTimer = defaultComboTimer;
        currentComboState = COMBO_STATES.None;
    }

    // Update is called once per frame
    void Update()
    {
        comboMoves();
        resetComboState();
    }

    void comboMoves()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {
            if(currentComboState== COMBO_STATES.Punch_3||currentComboState==COMBO_STATES.Kick_1||currentComboState==COMBO_STATES.Kick_2) {
                return;
            }
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if (currentComboState == COMBO_STATES.Punch_1)
            {
                playerAnimation.punch1();
            }
            else if (currentComboState == COMBO_STATES.Punch_2)
            {
                playerAnimation.punch2();
            }
            else
            {
                playerAnimation.punch3();
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if(currentComboState== COMBO_STATES.Punch_3||currentComboState==COMBO_STATES.Kick_2) {
                return;
            }
            if(currentComboState!= COMBO_STATES.Kick_1) {
                currentComboState = COMBO_STATES.Kick_1;
            }
            else
            {
                currentComboState = COMBO_STATES.Kick_2;
            }
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if (currentComboState == COMBO_STATES.Kick_1)
            {
                playerAnimation.kick1();
            }
            else
            {
                playerAnimation.kick2();
            }
        }
    }

    void resetComboState()
    {
        currentComboTimer -= Time.deltaTime;
        if (currentComboTimer <= 0)
        {
            currentComboState = COMBO_STATES.None;
            activateTimerToReset = false;
            currentComboTimer = defaultComboTimer;
        }
    }
}
