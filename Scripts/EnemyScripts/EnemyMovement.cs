using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private PlayerAnimation enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attackDistance = 1f;
    private float chasePlayerAfterAttack = 1f;

    private float currentAttackTime;
    private float defaultAttackTime = 2f;

    private bool followPlayer, attackPlayer;
    void Awake()
    {
        enemyAnim = GetComponentInChildren<PlayerAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }
    // Update is called once per frame
    void Update()
    {
        attack();
    }

    private void FixedUpdate()
    {
        followTarget();
    }

    void followTarget()
    {
        if(!followPlayer)
        {
            return;
        }
        if(Vector3.Distance(transform.position, playerTarget.position)>attackDistance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;
            if(myBody.velocity.sqrMagnitude!=0) {
                enemyAnim.walk(true);
            }
            else
            {
                enemyAnim.walk(false);
            }
        }
        else if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.walk(false);
            followPlayer= false;
            attackPlayer = true;
        }
    }

    void attack()
    {
        if (!attackPlayer)
        {
            return;
        }
        currentAttackTime += Time.deltaTime;
        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnim.enemyAttack(Random.Range(0, 3));
            currentAttackTime = 0;
        }
        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance+chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer= true;
        }
    }
}
