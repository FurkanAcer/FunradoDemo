using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    [SerializeField] internal int enemyLevel = 5;
    public bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    IEnumerator FOVRoutine()
    {
        while (true)
        {
            yield return true;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0 )
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, directionToTarget,distanceToTarget,obstructionMask))
                {
                    canSeePlayer = true;
                    KillEnemyIfPlayerLevelHigher();
                    KillPlayerIfEnemyLevelHigher();
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
    private void KillEnemyIfPlayerLevelHigher()
    {
        Collectable collectable = playerRef.GetComponent<Collectable>();
        if (collectable != null && collectable.playerLevel > enemyLevel)
        {
            collectable.playerLevel  += enemyLevel;
            collectable._tmPro.text = collectable.playerLevel.ToString();
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        Collectable collectable = playerRef.GetComponent<Collectable>();
        if (other.CompareTag("Player") && collectable != null && enemyLevel > collectable.playerLevel)
        {
            Destroy(playerRef);
        }

        if (other.CompareTag("Player") &&collectable != null && collectable.playerLevel > enemyLevel)
        {
            collectable.playerLevel  += enemyLevel;
            collectable._tmPro.text = collectable.playerLevel.ToString();
            Destroy(gameObject); 
        }

    }

    private void KillPlayerIfEnemyLevelHigher()
    {
        Collectable collectable = playerRef.GetComponent<Collectable>();
        if (collectable != null && enemyLevel> collectable.playerLevel )
        {
            Destroy(playerRef);
        }
    }

    
}