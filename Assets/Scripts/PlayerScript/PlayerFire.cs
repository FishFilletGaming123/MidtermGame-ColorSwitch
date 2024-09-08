using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform firePos;
    public float fireDelay;
    public GameObject bullet;
    public float bulletSpeed;
    public float firingRange = 50f;  // Maximum firing range

    private Enemy closestEnemy;

    void Start()
    {
        InvokeRepeating("Firing", 1, fireDelay);
    }

    void Update()
    {
        FindClosestEnemy();
        RotateTowardsClosestEnemy();
    }

    void Firing()
    {
        if (closestEnemy == null) return;

        GameObject bulletInstance = Instantiate(bullet, firePos.position, firePos.rotation);
        Rigidbody bulletRb = bulletInstance.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = firePos.forward * bulletSpeed;
        }
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        closestEnemy = null;

        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < firingRange * firingRange)
            {
                if (distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                }
            }
        }

        if (closestEnemy != null)
        {
            Debug.DrawLine(this.transform.position, closestEnemy.transform.position, Color.red);
        }
    }

    void RotateTowardsClosestEnemy()
    {
        if (closestEnemy == null) return;

        Vector3 directionToEnemy = (closestEnemy.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToEnemy);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    void VisualizeRange()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, firingRange);
    }
}
