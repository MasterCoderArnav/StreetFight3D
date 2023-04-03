using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool is_Player, is_Enemy;
    public GameObject hit_FX;

    void Start()
    {
        
    }

    void Update()
    {
        detectCollision();
    }

    void detectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if(hit.Length > 0 )
        {
            if (is_Player)
            {
                Vector3 hitFXPos = hit[0].transform.position;
                hitFXPos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFXPos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFXPos.x -= 0.3f;
                }
                Instantiate(hit_FX, hitFXPos, Quaternion.identity);
                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().applyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().applyDamage(damage, false);
                }
            }
            else if(is_Enemy)
            {
                Vector3 hitFXPos = hit[0].transform.position;
                hitFXPos.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFXPos.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFXPos.x -= 0.3f;
                }
                Instantiate(hit_FX, hitFXPos, Quaternion.identity);
                hit[0].GetComponent<HealthScript>().applyDamage(damage, false);
            }
            gameObject.SetActive(false);
        }
    }
}
