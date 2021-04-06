using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    private float distance;
    private float startTime;
    private GameManagerBehaviour gameManager;
    private void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehaviour>();

        Vector3 direction = startPosition - targetPosition; 

        gameManager.transform.rotation = Quaternion.AngleAxis(
            Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI,
            new Vector3(0, 0, 1)
        );
    }
    private void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    gameManager.Gold += 50;
                }
            }
            Destroy(gameObject);
        }
    }
}
