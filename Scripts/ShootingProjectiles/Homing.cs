using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class to make projectiles move
/// </summary>
public class Homing : MonoBehaviour
{
    [Tooltip("The distance this projectile will move each second.")]
    public float projectileSpeed = 3.0f;
    public float minAngleToRotate = 5.0f;

    private GameObject enemy = null;
    private float targetRadius = 10.0f;

    private void Start()
    {
        EnemyToTarget();
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called once per frame
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void Update()
    {
        MoveProjectile();
    }

    /// <summary>
    /// Description:
    /// Move the projectile in the direction it is heading
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void MoveProjectile()
    {
        if (enemy == null || !enemy.activeInHierarchy) {
            EnemyToTarget();
        }

        var directionToMove = (enemy == null) ? transform.up : (enemy.transform.position - transform.position);

        var angle = Vector3.Angle(transform.up, directionToMove);
        angle = (angle + 360) % 360;
        transform.Rotate(0, 0, Mathf.Min(angle, minAngleToRotate));

        // move the transform
        transform.position = transform.position + transform.up * projectileSpeed * Time.deltaTime;
    }

    private void EnemyToTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject localEnemy in enemies) {
            if (Vector3.Distance(localEnemy.transform.position, transform.position) <= targetRadius) {
                enemy = localEnemy;
                return;
            }
        }
    }
}