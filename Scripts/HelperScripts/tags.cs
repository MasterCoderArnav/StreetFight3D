using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags
{
    public const string MOVEMENT = "Movement";

    public const string PUNCH1_TRIGGER = "Punch1";
    public const string PUNCH2_TRIGGER = "Punch2";
    public const string PUNCH3_TRIGGER = "Punch3";

    public const string KICK1_TRIGGER = "Kick1";
    public const string KICK2_TRIGGER = "Kick2";

    public const string ATTACK1_TRIGGER = "Attack1";
    public const string ATTACK2_TRIGGER = "Attack2";
    public const string ATTACK3_TRIGGER = "Attack3";

    public const string IDLE_ANIMATION = "Idle";

    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    public const string STAND_UP_TRIGGER = "StandUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";
}

public class Axis
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags
{
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string RIGHT_ARM_TAG = "RightArm";
    public const string RIGHT_LEG_TAG = "RightLeg";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI_TAG = "HealthUI";
}