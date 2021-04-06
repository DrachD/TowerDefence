using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    private TowerData towerData;
    private void Start()
    {
        lastShotTime = Time.time;
        towerData = GetComponent<TowerData>();
        enemiesInRange = new List<GameObject>();
    }
    private void Update()
    {
        GameObject target = null;

        float minimalEnemyDistance = float.MaxValue;

        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            } 
        }

        if (target != null)
        {
            if (Time.time - lastShotTime > towerData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }

        }

        Vector3 direction = gameObject.transform.position - target.transform.position;
        gameObject.transform.rotation = Quaternion.AngleAxis(
            Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI, 
            new Vector3(0, 0, 1)
        );
    }
    private void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = towerData.CurrentLevel.bulletPrefab;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        GameObject newBullet = (GameObject) Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;

        BulletBehavior bulletBehavior = newBullet.GetComponent<BulletBehavior>();
        bulletBehavior.target = target.gameObject;
        bulletBehavior.startPosition = startPosition;
        bulletBehavior.targetPosition = targetPosition;
    }
    private void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }
}
