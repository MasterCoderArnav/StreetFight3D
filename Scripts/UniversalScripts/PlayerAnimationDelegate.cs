using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;
    public float standUpTimer = 2f;
    private PlayerAnimation playerAnimation;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip whooshSound, deadSound, groundHitSound, fallSound;

    private EnemyMovement enemyMovement;

    private PlayerMovement playerMovement;

    private ShakeCamera shakeCamera;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        audioSource= GetComponent<AudioSource>();
        if (gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }
        else if (gameObject.CompareTag(Tags.PLAYER_TAG))
        {
            playerMovement= GetComponentInParent<PlayerMovement>();
        }
        shakeCamera = GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }
    void leftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void leftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    void rightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void rightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    void leftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }

    void leftLegAttackOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }

    void rightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void rightLegAttackOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    void tagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.LEFT_ARM_TAG;
    }

    void UntagLeftArm()
    {
        leftArmAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void tagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.LEFT_LEG_TAG;
    }

    void UntagLeftLeg()
    {
        leftLegAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void enemyStandUp()
    {
        StartCoroutine(enemyStandUpAfterTime());
    }

    IEnumerator enemyStandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        playerAnimation.standUp();
    }

    public void attackFXSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    public void characterDeadSound()
    {
        audioSource.volume = 1.0f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }

    public void enemyKnockedDown()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    public void enemyHitGround()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    void playerHitGround()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    void playerDisableMovement()
    {
        //Time.timeScale = 0.0f;
    }

    void disableMovement()
    {
        enemyMovement.enabled = false;
        transform.parent.gameObject.layer = 0;
    }

    //Disable attack on enemy while on ground
    void enableMovement()
    {
        enemyMovement.enabled = true;
        transform.parent.gameObject.layer = 7;
    }

    void shakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    void characterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {

        Destroy(gameObject);
        EnemyManager.instance.spawnEnemy = true;
    }
}
